import http from 'node:http';
import {readFile,stat} from 'node:fs/promises';
import {join,extname,normalize} from 'node:path';
import {fileURLToPath} from 'node:url';
const root=join(fileURLToPath(new URL('.',import.meta.url)),'WebOnlyWar');
const port=Number(process.env.PORT||3000);
const types={'.html':'text/html; charset=utf-8','.json':'application/json; charset=utf-8'};
http.createServer(async(req,res)=>{
  try{
    const raw=decodeURIComponent((req.url||'/').split('?')[0]);
    const safe=normalize(raw).replace(/^(\.\.(\/|\\|$))+/,'');
    let file=join(root,safe==='/'?'index.html':safe);
    if(!file.startsWith(root))throw new Error('bad path');
    try{if((await stat(file)).isDirectory())file=join(file,'index.html')}catch{}
    let body;try{body=await readFile(file)}catch{body=await readFile(join(root,'index.html'));file=join(root,'index.html')}
    res.writeHead(200,{'content-type':types[extname(file)]||'application/octet-stream','cache-control':extname(file)==='.html'?'no-cache':'public,max-age=3600','x-content-type-options':'nosniff'});
    res.end(body);
  }catch{res.writeHead(500);res.end('OnlyWar server error')}
}).listen(port,'0.0.0.0',()=>console.log('OnlyWar listening on '+port));
