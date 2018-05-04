var duilian = $(".duilian");
	var duilian_close = $(".duilian_close");
	
	var screen_w = screen.width;
	if(screen_w>1024){duilian.show();}
	$(window).scroll(function(){
		var scrollTop = $(window).scrollTop();
		duilian.stop().animate({top:scrollTop+260});
	});
	duilian_close.click(function(){
		$(this).parent().hide();
		return false;
	});
