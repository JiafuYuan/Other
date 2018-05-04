var speed=30;
var ta=document.getElementById("demo");
var ta1=document.getElementById("demo1");
var ta2=document.getElementById("demo2");
ta2.innerHTML=ta1.innerHTML;
function Marquee1(){
if(ta2.offsetWidth-ta.scrollLeft<=0)
ta.scrollLeft-=ta1.offsetWidth
else{
ta.scrollLeft++;
}
}
var MyMar1=setInterval(Marquee1,speed);
ta.onmouseover=function() {clearInterval(MyMar1)};
ta.onmouseout=function() {MyMar1=setInterval(Marquee1,speed)};