(function(e){function t(t){for(var r,u,l=t[0],s=t[1],i=t[2],p=0,f=[];p<l.length;p++)u=l[p],Object.prototype.hasOwnProperty.call(o,u)&&o[u]&&f.push(o[u][0]),o[u]=0;for(r in s)Object.prototype.hasOwnProperty.call(s,r)&&(e[r]=s[r]);c&&c(t);while(f.length)f.shift()();return a.push.apply(a,i||[]),n()}function n(){for(var e,t=0;t<a.length;t++){for(var n=a[t],r=!0,l=1;l<n.length;l++){var s=n[l];0!==o[s]&&(r=!1)}r&&(a.splice(t--,1),e=u(u.s=n[0]))}return e}var r={},o={app:0},a=[];function u(t){if(r[t])return r[t].exports;var n=r[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,u),n.l=!0,n.exports}u.m=e,u.c=r,u.d=function(e,t,n){u.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},u.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},u.t=function(e,t){if(1&t&&(e=u(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(u.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var r in e)u.d(n,r,function(t){return e[t]}.bind(null,r));return n},u.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return u.d(t,"a",t),t},u.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},u.p="/";var l=window["webpackJsonp"]=window["webpackJsonp"]||[],s=l.push.bind(l);l.push=t,l=l.slice();for(var i=0;i<l.length;i++)t(l[i]);var c=s;a.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("56d7")},"56d7":function(e,t,n){"use strict";n.r(t);var r=n("2b0e"),o=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{attrs:{id:"app"}},[n("Home",{attrs:{msg:"Hello world!"}})],1)},a=[],u=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"home"},[n("h1",[e._v(e._s(e.msg))]),e._m(0),n("router-link",{staticClass:"nav-link",attrs:{to:"TestPage"}},[e._v("TestPage")])],1)},l=[function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("p",[e._v("Welcome to your new single-page application, built with "),n("a",{attrs:{href:"https://vuejs.org",target:"_blank"}},[e._v("Vue.js")]),e._v(".")])}],s={name:"Home",props:{msg:String}},i=s,c=n("2877"),p=Object(c["a"])(i,u,l,!1,null,"eacedf68",null),f=p.exports,v={name:"app",components:{Home:f}},d=v,h=Object(c["a"])(d,o,a,!1,null,null,null),m=h.exports,g=n("8c4f"),_=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"home"},[n("h1",[e._v(e._s(e.msg))]),n("p",[e._v("no")])])},b=[],y={name:"Test",props:{msg:String}},w=y,j=Object(c["a"])(w,_,b,!1,null,"14e8e250",null),O=j.exports;r["a"].use(g["a"]);var x=new g["a"]({routes:[{path:"/",component:f},{path:"/Test",component:O}]});r["a"].config.productionTip=!0,new r["a"]({router:x,render:function(e){return e(m)}}).$mount("#app")}});
//# sourceMappingURL=app.994fd02d.js.map