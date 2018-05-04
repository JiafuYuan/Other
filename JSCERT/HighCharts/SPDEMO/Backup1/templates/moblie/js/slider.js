(function(a,b){a.ui.define("slider",{_data:{viewNum:1,imgInit:2,itemRender:null,imgZoom:false,loop:false,stopPropagation:false,springBackDis:15,autoPlay:true,autoPlayTime:4000,animationTime:400,showArr:true,showDot:true,slide:null,slideend:null,index:0,_stepLength:1,_direction:1},_create:function(){var g=this,e=0,d,c=[],f=g.data("content");g._initConfig();(g.root()||g.root(a("<div></div>"))).addClass("ui-slider").appendTo(g.data("container")||(g.root().parent().length?"":document.body)).html('<div class="ui-slider-wheel"><div class="ui-slider-group">'+(function(){if(g.data("itemRender")){var h=g.data("itemRender");while(d=h.call(g,e++)){c.push('<div class="ui-slider-item">'+d+"</div>")}}else{while(d=f[e++]){c.push('<div class="ui-slider-item"><a href="'+d.href+'"><img lazyload="'+d.pic+'"/></a>'+(d.title?"<p>"+d.title+"</p>":"")+"</div>")}}c.push(g.data("loop")?'</div><div class="ui-slider-group">'+c.join("")+"</div></div>":"</div></div>");return c.join("")}()));g._addDots()},_setup:function(g){var e=this,c=e.root().addClass("ui-slider");e._initConfig();if(!g){var d=c.children(),f=a('<div class="ui-slider-group"></div>').append(d.addClass("ui-slider-item"));c.empty().append(a('<div class="ui-slider-wheel"></div>').append(f).append(e.data("loop")?f.clone():""));e._addDots()}else{e.data("loop")&&a(".ui-slider-wheel",c).append(a(".ui-slider-group",c).clone())}},_init:function(){var f=this,d=f.data("index"),c=f.root(),e=a.proxy(f._eventHandler,f);f._setWidth();a(f.data("wheel")).on("touchstart touchmove touchend touchcancel webkitTransitionEnd",e);a(window).on("ortchange",e);a(".ui-slider-pre",c).on("tap",function(){f.pre()});a(".ui-slider-next",c).on("tap",function(){f.next()});f.on("destroy",function(){clearTimeout(f.data("play"));a(window).off("ortchange",e)});f.data("autoPlay")&&f._setTimeout()},_initConfig:function(){var c=this._data;if(c.viewNum>1){c.loop=false;c.showDot=false;c.imgInit=c.viewNum+1}},_addDots:function(){var f=this,c=f.root(),e=a(".ui-slider-item",c).length/(f.data("loop")?2:1),d=[];if(f.data("showDot")){d.push('<p class="ui-slider-dots">');while(e--){d.push("<b></b>")}d.push("</p>")}f.data("showArr")&&(d.push('<span class="ui-slider-pre"><b></b></span><span class="ui-slider-next"><b></b></span>'));c.append(d.join(""))},_setWidth:function(){var s=this,f=s._data,t=s.root(),c=Math.ceil(t.width()/f.viewNum),u=t.height(),n=f.loop,q=a(".ui-slider-item",t).toArray(),g=q.length,p=a(".ui-slider-wheel",t).width(c*g)[0],r=a(".ui-slider-dots b",t).toArray(),e=a("img",t).toArray(),v=e.concat(),d={},m,k,h=f.imgInit||g;f.showDot&&(r[0].className="ui-slider-dot-select");if(f.imgZoom){a(v).on("load",function(){var l=this.height,i=this.width,o=Math.min(l,u),j=Math.min(i,c);if(l/u>i/c){this.style.cssText+="height:"+o+"px;width:"+o/l*i+"px;"}else{this.style.cssText+="height:"+j/i*l+"px;width:"+j+"px"}this.onload=null})}for(m=0;m<g;m++){q[m].style.cssText+="width:"+c+"px;position:absolute;-webkit-transform:translate3d("+m*c+"px,0,0);z-index:"+(900-m);d[m]=n?(m>g/2-1?m-g/2:m):m;if(m<h){k=v.shift();k&&(k.src=k.getAttribute("lazyload"));if(f.loop){k=e[m+g/2];k&&(k.src=k.getAttribute("lazyload"))}}}s.data({root:t[0],wheel:p,items:q,lazyImgs:v,allImgs:e,length:g,width:c,height:u,dots:r,dotIndex:d,dot:r[0]});return s},_eventHandler:function(d){var c=this;switch(d.type){case"touchmove":c._touchMove(d);break;case"touchstart":c._touchStart(d);break;case"touchcancel":case"touchend":c._touchEnd();break;case"webkitTransitionEnd":c._transitionEnd();break;case"ortchange":c._resize.call(c);break}},_touchStart:function(d){var c=this;c.data({pageX:d.touches[0].pageX,pageY:d.touches[0].pageY,S:false,T:false,X:0});c.data("wheel").style.webkitTransitionDuration="0ms"},_touchMove:function(g){var h=this._data,i=h.X=g.touches[0].pageX-h.pageX;if(!h.T){var c=h.index,f=h.length,d=Math.abs(i)<Math.abs(g.touches[0].pageY-h.pageY);h.loop&&(h.index=c>0&&(c<f-1)?c:(c===f-1)&&i<0?f/2-1:c===0&&i>0?f/2:c);d||clearTimeout(h.play);h.T=true;h.S=d}if(!h.S){h.stopPropagation&&g.stopPropagation();g.preventDefault();h.wheel.style.webkitTransform="translate3d("+(i-h.index*h.width)+"px,0,0)"}},_touchEnd:function(){var d=this,e=d._data;if(!e.S){var f=e.springBackDis,c=e.X<=-f?Math.ceil(-e.X/e.width):(e.X>f)?-Math.ceil(e.X/e.width):0;e._stepLength=Math.abs(c);d._slide(e.index+c)}},_slide:function(d,h){var f=this,g=f._data,e=g.length,c=e-g.viewNum+1;if(-1<d&&d<c){f._move(d)}else{if(d>=c){if(!g.loop){f._move(c-(h?2:1));g._direction=-1}else{g.wheel.style.cssText+="-webkit-transition:0ms;-webkit-transform:translate3d(-"+(e/2-1)*g.width+"px,0,0);";g._direction=1;a.later(function(){f._move(e/2)},20)}}else{if(!g.loop){f._move(h?1:0)}else{g.wheel.style.cssText+="-webkit-transition:0ms;-webkit-transform:translate3d(-"+(e/2)*g.width+"px,0,0);";a.later(function(){f._move(e/2-1)},20)}g._direction=1}}return f},_move:function(d){var f=this._data,e=f.dotIndex[d];this.trigger("slide",e);if(f.lazyImgs.length){var c=f.allImgs[d];c&&c.src||(c.src=c.getAttribute("lazyload"))}if(f.showDot){f.dot.className="";f.dots[e].className="ui-slider-dot-select";f.dot=f.dots[e]}f.index=d;f.wheel.style.cssText+="-webkit-transition:"+f.animationTime+"ms;-webkit-transform:translate3d(-"+d*f.width+"px,0,0);"},_transitionEnd:function(){var f=this,g=f._data;f.trigger("slideend",g.dotIndex[g.index]);if(g.lazyImgs.length){for(var e=g._stepLength,d=0;d<e;d++){var c=g.lazyImgs.shift();c&&(c.src=c.getAttribute("lazyload"));if(g.loop){c=g.allImgs[g.index+g.length/2];c&&!c.src&&(c.src=c.getAttribute("lazyload"))}}g._stepLength=1}f._setTimeout()},_setTimeout:function(){var c=this,d=c._data;if(!d.autoPlay){return c}clearTimeout(d.play);d.play=a.later(function(){c._slide.call(c,d.index+d._direction,true)},d.autoPlayTime);return c},_resize:function(){var g=this,h=g._data,e=h.root.offsetWidth/h.viewNum,f=h.length,c=h.items;if(!e){return g}h.width=e;clearTimeout(h.play);for(var d=0;d<f;d++){c[d].style.cssText+="width:"+e+"px;-webkit-transform:translate3d("+d*e+"px,0,0);"}h.wheel.style.removeProperty("-webkit-transition");h.wheel.style.cssText+="width:"+e*f+"px;-webkit-transform:translate3d(-"+h.index*e+"px,0,0);";h._direction=1;g._setTimeout();return g},pre:function(){var c=this;c._slide(c.data("index")-1);return c},next:function(){var c=this;c._slide(c.data("index")+1);return c},stop:function(){var c=this;clearTimeout(c.data("play"));c.data("autoPlay",false);return c},resume:function(){var c=this;c.data("_direction",1);c.data("autoPlay",true);c._setTimeout();return c}})})(Zepto);