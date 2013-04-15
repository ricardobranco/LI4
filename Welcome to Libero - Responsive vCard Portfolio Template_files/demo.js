$(document).ready(function() {



	$('#opt').find('li a').on('click', function(e){
		e.preventDefault();

		var color = $(this).attr('class');

		$('#color').attr('href','css/colors/schemes/'+color+'.css');
		$('#opt li').removeClass('active');
		$(this).parent().addClass('active');



	});

	$('#dark_light').find('li a').on('click', function(e){
		e.preventDefault();

		var version = $(this).attr('class');

		$('#version').attr('href','css/colors/'+version+'.css');
		$('#dark_light li').removeClass('active');
		$(this).parent().addClass('active');



	});

	$('#optbut').on('click', function(e){
		e.preventDefault();

		$('#options').animate(
		{left : 0+'px'},
             {
                duration: 'slow',
                    
             },1000);
	});

	$('#opt2').find('li a').on('click', function(e){
		e.preventDefault();

		var el = $(this).attr('class');
		$('html').addClass('blurred').removeClass('patterned');
		$('html').css('background-image', 'url(images/bgs/blurred/' + el + '.jpg)');
		$('#opt2 li, #opt3 li').removeClass('active');
		$(this).parent().addClass('active');

	});

	$('#opt3').find('li a').on('click', function(e){
		e.preventDefault();

		var el = $(this).attr('class');

		$('html').addClass('patterned').removeClass('blurred');
		$('html').css('background-image', 'url(images/bgs/patterned/' + el + '.png)');
		$('#opt3 li, #opt2 li').removeClass('active');
		$(this).parent().addClass('active');

	});
	

	$('a.close').on('click', function(e){
		e.preventDefault();

		$('#options').animate(
		{left : -190+'px'},
             {
                duration: 'slow',
                    
             },1000);		
	});

});