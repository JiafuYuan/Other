$(function () {
    var st = 180;
    $('.nav_all>li').mouseenter(function () {
        $(this).find('ul').stop(false, true).slideDown(st);
    }).mouseleave(function () {
        $(this).find('ul').stop(false, true).slideUp(st);
    });
	$('.nav_all>li').mouseenter(function () {
        $(this).find('div').stop(false, true).slideDown(st);
    }).mouseleave(function () {
        $(this).find('div').stop(false, true).slideUp(st);
    });
});