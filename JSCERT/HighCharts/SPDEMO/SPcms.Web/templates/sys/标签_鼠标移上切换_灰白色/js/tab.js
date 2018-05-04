$(function () {
    $('.tab_top>li').mouseenter(function () {
		$(this).attr("id","tab_1");
		for(i=0;i<$('.tab_top>li').length;i++){
			if($('.tab_top>li:eq('+i+')').attr("id")=="tab_1"){
					$('.tab_top>li:eq('+i+')').addClass("selected");
					$('.tab_content>li:eq('+i+')').fadeIn("slow")
					$('.tab_content').css("height",$('.tab_content>li:eq('+i+')').height()+20);
				}else{
					$('.tab_top>li:eq('+i+')').removeClass("selected");
					$('.tab_content>li:eq('+i+')').fadeOut("slow")
				}
				$('.tab_top>li:eq('+i+')').attr("id","tab_0");
		}
    })
});