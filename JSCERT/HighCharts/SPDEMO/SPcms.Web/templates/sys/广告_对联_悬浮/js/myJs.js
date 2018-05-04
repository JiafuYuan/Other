lastScrollY = 0;
function heartBeat() {
	var diffY;
	if (document.documentElement && document.documentElement.scrollTop){
		diffY = document.documentElement.scrollTop;
		}
	else if (document.body){
		diffY = document.body.scrollTop
		}
	percent = .1 * (diffY - lastScrollY);
	if (percent > 0) percent = Math.ceil(percent);
	else percent = Math.floor(percent);
	document.getElementById("coup1").style.top = parseInt(document.getElementById("coup1").style.top) + percent + "px";
	document.getElementById("coup2").style.top = parseInt(document.getElementById("coup2").style.top) + percent + "px";
	lastScrollY = lastScrollY + percent;
}
window.setInterval("heartBeat()", 1);