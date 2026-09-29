import http from 'node:http';
import https from 'node:https';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const root = path.resolve(here, 'public');
const port = Number(process.env.PORT || 8080);
const upstreamUrl = new URL(process.env.ONLYWAR_API_ORIGIN || 'https://exposiqo-live-production.up.railway.app');

const types = {
  '.html':'text/html; charset=utf-8',
  '.js':'application/javascript; charset=utf-8',
  '.wasm':'application/wasm',
  '.data':'application/octet-stream',
  '.css':'text/css; charset=utf-8',
  '.png':'image/png',
  '.jpg':'image/jpeg',
  '.jpeg':'image/jpeg',
  '.webp':'image/webp',
  '.ico':'image/x-icon',
  '.json':'application/json; charset=utf-8'
};

function commonHeaders(extra={}) {
  return {
    'X-Content-Type-Options':'nosniff',
    'Referrer-Policy':'same-origin',
    'Permissions-Policy':'camera=(), microphone=(self), geolocation=()',
    ...extra
  };
}

function proxyApi(req,res,url){
  const chunks=[];
  req.on('data',c=>chunks.push(c));
  req.on('end',()=>{
    const body=Buffer.concat(chunks);
    const headers={
      'accept':'application/json',
      'user-agent':'OnlyWar-WebGL-Production/1.0'
    };
    if(req.headers['content-type']) headers['content-type']=req.headers['content-type'];
    if(body.length) headers['content-length']=String(body.length);

    const client=upstreamUrl.protocol==='http:'?http:https;
    const upstream=client.request({
      protocol: upstreamUrl.protocol,
      hostname: upstreamUrl.hostname,
      port: upstreamUrl.port || undefined,
      path: url.pathname + url.search,
      method: req.method,
      headers
    },reply=>{
      res.writeHead(reply.statusCode||502,commonHeaders({
        'content-type':reply.headers['content-type']||'application/json',
        'cache-control':'no-store'
      }));
      if(req.method==='HEAD'){res.end(); reply.resume(); return;}
      reply.pipe(res);
    });
    upstream.setTimeout(15000,()=>upstream.destroy(new Error('upstream timeout')));
    upstream.on('error',()=>{
      if(!res.headersSent) res.writeHead(502,commonHeaders({'content-type':'application/json; charset=utf-8','cache-control':'no-store'}));
      res.end(JSON.stringify({error:'Online server unavailable'}));
    });
    if(body.length) upstream.write(body);
    upstream.end();
  });
}

function serveFile(req,res,pathname){
  const rel=pathname==='/'?'index.html':decodeURIComponent(pathname).replace(/^\/+/, '');
  const filename=path.resolve(root,rel);
  if(filename!==root && !filename.startsWith(root+path.sep)){
    res.writeHead(403,commonHeaders({'content-type':'text/plain; charset=utf-8'}));res.end('Forbidden');return;
  }
  let stat;
  try{stat=fs.statSync(filename);}catch{}
  if(!stat || !stat.isFile()){
    res.writeHead(404,commonHeaders({'content-type':'text/plain; charset=utf-8'}));res.end('Not found');return;
  }
  const gzip=filename.endsWith('.gz');
  const base=gzip?filename.slice(0,-3):filename;
  const ext=path.extname(base).toLowerCase();
  const headers=commonHeaders({
    'Content-Type':types[ext]||'application/octet-stream',
    'Content-Length':String(stat.size),
    'Cache-Control': ext==='.html'?'no-store':'public, max-age=3600'
  });
  if(gzip) headers['Content-Encoding']='gzip';
  res.writeHead(200,headers);
  if(req.method==='HEAD'){res.end();return;}
  fs.createReadStream(filename).pipe(res);
}

http.createServer((req,res)=>{
  let url;
  try{url=new URL(req.url||'/','http://localhost');}
  catch{res.writeHead(400);res.end('Bad request');return;}
  if(url.pathname==='/health'){
    res.writeHead(200,commonHeaders({'content-type':'application/json; charset=utf-8','cache-control':'no-store'}));
    res.end(JSON.stringify({ok:true,service:'onlywar-webgl'}));return;
  }
  if(url.pathname.startsWith('/onlywar-api/')){proxyApi(req,res,url);return;}
  serveFile(req,res,url.pathname);
}).listen(port,'0.0.0.0',()=>console.log('ONLYWAR_CLOUD_READY port='+port));
