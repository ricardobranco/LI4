

/***************************************************
                ON LOAD ACTIONS
***************************************************/
jQuery(window).load(function () {
  //$('.main').fadeIn(1000);

    var $container = $('#portfolio_items');
      $container.isotope({
        itemSelector : '.item',
        animationEngine : 'jquery',
        animationOptions: {
            duration: 250,
            easing: 'linear',
            queue: false
        }
      });
});

/***************************************************
                 ON WINDOW RESIZE ACIONS
***************************************************/

jQuery(window).resize(function() {
	menu_auto_width();

    var $container = $('#portfolio_items');
        $container.isotope({
            itemSelector : '.item',
            animationEngine : 'jquery',
            animationOptions: {
                duration: 250,
                easing: 'linear',
                queue: false
            }
    });

});

jQuery(document).ready(function() {

$('.main').fadeIn(1000);

/***************************************************
                 NAVIGATION 
***************************************************/

// main nav functionality
$('.nav li a').on('click',function(e){
  e.preventDefault();
	 // Scroll to top on click
    $('body,html').animate({
        scrollTop: 0
    }, 0); 
    
    var anchor = $(this);
    var anchor_id = anchor.attr('href');


    $('.content_wrap').slideUp(500);

    $('.navigation_wrap').addClass('active');
    $('.hidden_data').fadeIn(600);

    $('.content_box').slideUp(550);
    $(anchor_id+'.content_box').slideDown(600);
    $('.hideable').hide();	

    $('.nav li').removeClass('active');
    anchor.parent().addClass('active');

    if(anchor_id == '#resume' || anchor_id == ''){
        loadSkills();
        $('.under_wrap').slideDown();
    }
    else{
        $('.under_wrap').slideUp();
    }

    if(anchor_id ==''){
        $('#top').fadeIn();
        $('.hideable').show();
    }
   
   //Activate Gmap
   if ($('#map_canvas').parent().parent().is(':visible')) {
		initialize_gmap();
	 } 
   
}); 

// close all other divs and return to start
$('#logo').on('click', function(e){
    e.preventDefault();

    $('.content_box ').slideUp(550);
    $('.content_wrap').slideDown(500);

    $('.hidden_data').fadeOut(600);
    $('.under_wrap').slideUp();
    $('.hideable').hide();  

    $('.navigation_wrap').removeClass('active');
    $('#top').fadeOut();

    $('.nav li').removeClass('active');

});

// scroll body to 0px on click
$('#top').click(function () {
  $('body,html').animate({
    scrollTop: 0
  }, 800);
  return false;
});

// on window change detect screen size
if (matchMedia) {
    var mq = window.matchMedia("only screen and (max-width: 600px)");
    mq.addListener(WidthChange);
    WidthChange(mq);
}

// main nav functionality when nav is responsive



   

 


/***************************************************
    JQUERY COLORBOX / PORTFOLIO COLORBOX
***************************************************/

$("a.colorbox").colorbox({
  rel:'gal',
  maxWidth: "98%",
  maxHeight: "98%"
});

// here you can change iframe width and height
$("a.iframe").colorbox({
    iframe:true, 
    innerWidth:425, 
    innerHeight:344,
    maxWidth: "98%",
    maxHeight: "98%",
    rel:'video'
});


/***************************************************
                 CONTACT FORM SUBMIT 
***************************************************/

$('#contact_form').submit(function(e){
	e.preventDefault();
	
    $('#submit_msg').html('');
	$('#submit_msg').removeClass('success').removeClass('error');
	
	var validate = validate_form();
	if(validate == true){
			var $f = $(this);
		$.post('ajax/form_submit.php', $f.serialize(), function(response){
			eval('var response='+response);
			if(response.status == false){
				$('#submit_msg').addClass('error');
	 		} else {
				$('#submit_msg').addClass('success');
	 		}
	 		$('#submit_msg').html(response.msg);
		});
	}
	
});

/***************************************************
    JQUERY ISOTOPE / PORTFOLIO FILTER
***************************************************/

var $container = $('#portfolio_items');

// filter items when filter link is clicked
$('#portfolio_filter a').click(function(e){
  e.preventDefault();
    
    var selector = $(this).attr('data-filter');
    $container.isotope({ filter: selector });
    
    $("#portfolio_filter li").removeClass("current");
    $(this).closest("li").addClass("current");

    return false;
});

	
/***************************************************
               REFRESH CAPTCHA
***************************************************/

$('#refresh_captcha').click(function(e){
	e.preventDefault();
	refresh_captcha();
});

refresh_captcha();

});


/***************************************************
                 VALIDATE FORM FUNCTION
***************************************************/

function validate_form() {
    //define values
    var status = true;
    var name = $("input#name").val(); 
    var email = $("input#email").val(); 
    var message = $("textarea#message").val();        
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/; 

    //input fields and textbox
    var input_name = $("input#name");
    var input_email = $("input#email");
    var input_message = $("#message");
    
    //name
    if(name == ""){
        input_name.addClass('error-form');
        setTimeout( function() {
            input_name.removeClass('error-form');
        }, 3000 );
        status = false;
    }
    
    // Email
    if(email == "" || reg.test(email) == false){
        input_email.addClass('error-form');
        setTimeout( function() {
            input_email.removeClass('error-form');
        }, 3000 );
        status = false;
    }

    //Text message
    if(message == ""){
        input_message.addClass('error-form');
        setTimeout( function() {
            input_message.removeClass('error-form');
        }, 3000 );
        status = false;
    }
   
   return status;
}

/***************************************************
                 GENERATE CAPTCHA FUNCTION
***************************************************/

function refresh_captcha(){

    $.post('ajax/generate_captcha.php', '', function(response) {	
    			eval('var response='+response);
    			if(response.status == true){
    		 		$('#form_captcha').html('<img src="'+response.image_src+'"/>');
    		 	} else {
    		 		$('#form_captcha').closest("li").remove();
    		 	}
    });

}

/*-----------------------------------------------------------------------------------*/
/*  LOAD SKILLS
/*-----------------------------------------------------------------------------------*/

function loadSkills(){

    $('.skill_set').each(function() {
        var skill = $(this);
        var skill_width = $(this).attr('data-skill');  

       // skill.css('width', skill_width+'%');     
        skill.animate({
            width: skill_width+'%'
        },2000);

    });

}

/*-----------------------------------------------------------------------------------*/
/*  MATCH MEDIA RESPONSIVE jQUERY PLUGIN
/*-----------------------------------------------------------------------------------*/

function WidthChange(mq) {
    if (mq.matches) {       
        $('.navigation_wrap').addClass('responsive');
    }
    menu_auto_width();
}

/*-----------------------------------------------------------------------------------*/
/*  AUTO RESIZE MENU
/*-----------------------------------------------------------------------------------*/

function menu_auto_width(){
	var main_width = $('div.main').width();
	var num_items = $('.nav li').length;
	var nav_width = (main_width - (num_items - 1)) / num_items;
	var last_width = main_width - (num_items - 1) - ((num_items - 1) * nav_width) - 0.5;
	$('.nav li').width(nav_width);
	$('.nav li:last-child').width(last_width);
}