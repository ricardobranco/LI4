var $container = $('#masonry');

$container.imagesLoaded(function() {
    $container.masonry({
        itemSelector: '.box',
        isAnimated: true
    });
});

$(window).resize(function() {
    $container.masonry({
        itemSelector: '.box',
        isAnimated: true
    });
});

$('.pad a.thumbnail').hover(function() {
    $(this).find('.overlay').slideDown('fast');
}, function() {
    $(this).find('.overlay').slideUp('fast');
});
$('input:visible, button,textarea').removeClass('disabled').attr('disabled', false);
/*
 * ====================================================
 * Ninja Shuriken AJAX
 * ====================================================
 */
$('.shuriken').click(function() {
    var item = $(this).attr('rel');
    var shurikens = $(this);
    $.get('ajax_online/shuriken/' + item, function(data) {
        shurikens.find('b').html(data);
    });

    return false;
});

$('.shuriken_btn').click(function() {
    return false;
});

/*
 * ====================================================
 * Ninja reset Login AJAX
 * ====================================================
 */
$('#resetPassword').validate(
        {
            errorPlacement: function(error, element) {
                return true;
            },
            submitHandler: function() {
                $("#form_login .log").html('');
                $.post('ajax/reset', $('#resetPassword').serialize(), function(data) {
                    var obj = JSON.parse(data);
                    $("#resetPassword .log").html(obj.content);
                });
            }
        }
);

/*
 * ====================================================
 * Ninja Login AJAX
 * ====================================================
 */
$("#form_login").validate(
        {
            submitHandler: function() {
                $("#form_login .log").html('');
                if ($('#form_login .bar').width() == 0)
                    $('#form_login .bar').width('100%');
                $.post('ajax/login', $('#form_login').serialize(), function(data) {
                    $('input, button').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#form_login .log").html(obj.content);
                    if (obj.value == 0) {
                        $('.bar').hide().width('0');
                        $('input, button').removeClass('disabled').attr('disabled', false);
                        $('input:visible,textarea:visible').val('');
                    }
                });
            }
        }
);

/*
 * ====================================================
 * Ninja reset password AJAX
 * ====================================================
 */
$("#form_reset").validate(
        {
            rules: {
                repassword: {
                    equalTo: "#password"
                }
            },
            submitHandler: function() {
                $("#form_reset .log").html('');
                if ($('#form_reset .bar').width() == 0)
                    $('#form_reset .bar').width('100%');
                $.post('ajax/reset_process', $('#form_reset').serialize(), function(data) {
                    $('input, button').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#form_reset .log").html(obj.content);
                    if (obj.value == 0) {
                        $('.bar').hide().width('0');
                        $('input, button').removeClass('disabled').attr('disabled', false);
                        $('input:visible,textarea:visible').val('');
                    }
                });
            }
        }
);

/*
 * ====================================================
 * Customer Login AJAX
 * ====================================================
 */
$("#form_login_c").validate(
        {
            submitHandler: function() {
                $("#form_login_c .log").html('');
                if ($('#form_login_c .bar').width() == 0)
                    $('#form_login_c .bar').width('100%');
                $.post('ajax/customer_login', $('#form_login_c').serialize(), function(data) {
                    $('input, button').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#form_login_c .log").html(obj.content);
                    if (obj.value == 0) {
                        $('.bar').hide().width('0');
                        $('input, button').removeClass('disabled').attr('disabled', false);
                        $('input:visible,textarea:visible').val('');
                    }
                });
            }
        }
);

/*
 * ====================================================
 * Ninja Register AJAX
 * ====================================================
 */

$.validator.addMethod("loginRegex", function(value, element) {
    return this.optional(element) || /^[a-z0-9\-]+$/i.test(value);
}, "Username must contain only letters, numbers, or dashes.");

$("#form_register").validate(
        {
            rules: {
                repassword: {
                    equalTo: "#password"
                },
                user: {
                    required: true,
                    loginRegex: true
                }
            },
            submitHandler: function() {
                $("#form_register .log").html('');
                if ($('#form_register .bar').width() == 0)
                    $('#form_register .bar').width('100%');

                $.post('ajax/register', $('#form_register').serialize(), function(data) {
                    $('input:visible,textarea:visible, button').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#form_register .log").html(obj.content);
                    if (obj.value == 0) {
                        $('.bar').hide().width('0');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    } else {
                        $('input:visible,textarea:visible').val('');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    }
                });
            }
        }
);
/*
 * ====================================================
 * Ninja update password AJAX
 * ====================================================
 */
$("#form_password").validate(
        {
            rules: {
                repassword: {
                    equalTo: "#newpassword"
                }
            },
            submitHandler: function() {
                $("#form_password .log").html('');
                if ($('#form_password .bar').width() == 0)
                    $('#form_password .bar').width('100%');

                $.post('ajax_online/password', $('#form_password').serialize(), function(data) {
                    $('input:visible,textarea:visible, button').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#form_password .log").html(obj.content);
                    if (obj.value == 0) {
                        $('.bar').hide().width('0');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    } else {
                        $('input:visible,textarea:visible').val('');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    }
                });
            }
        }
);

/*
 * ====================================================
 * Ninja update payment AJAX
 * ====================================================
 */
$("#form_payment").validate(
        {
            submitHandler: function() {
                $("#form_payment .log").html('');
                if ($('#form_payment .bar').width() == 0)
                    $('#form_payment .bar').width('100%');

                $.post('ajax_online/payment', $('#form_payment').serialize(), function(data) {
                    $('input:visible,textarea:visible, button').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#form_payment .log").html(obj.content);
                    if (obj.value == 0) {
                        $('.bar').hide().width('0');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    } else {
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    }
                });
            }
        }
);
/*
 * ====================================================
 * customer Register AJAX
 * ====================================================
 */
$("#c_form_register").validate(
        {
            rules: {
                crepwd: {
                    equalTo: "#cpwd"
                }
            },
            submitHandler: function() {
                $("#c_form_register .log").html('');
                if ($('#c_form_register .bar').width() == 0)
                    $('#c_form_register .bar').width('100%');
                $.post('ajax/customer_register', $('#c_form_register').serialize(), function(data) {
                    $('input:visible,textarea:visible, button').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#c_form_register .log").html(obj.content);
                    if (obj.value == 0) {
                        $('.bar').hide().width('0');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    } else {
                        $('input:visible,textarea:visible').val('');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    }
                });
            }
        }
);
/*
 * ====================================================
 * contact AJAX
 * ====================================================
 */
$("#form_contact").validate(
        {
            submitHandler: function() {
                $("#form_contact .log").html('');
                if ($('#form_contact .bar').width() == 0)
                    $('#form_contact .bar').width('100%');
                $.post('ajax/contact', $('#form_contact').serialize(), function(data) {
                    $('input:visible,textarea:visible, button').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#form_contact .log").html(obj.content);
                    if (obj.value == 0) {
                        $('.bar').hide().width('0');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    } else {
                        $('input:visible,textarea:visible').val('');
                        $('input:visible,textarea:visible, button').removeClass('disabled').attr('disabled', false);
                    }
                });
            }
        }
);

/*
 * ====================================================
 * Landing page Ajax
 * ====================================================
 */
$('.alert .close').live('click', function() {
    $container.masonry({
        itemSelector: '.box',
        isAnimated: true
    });
});
$("#form_subscribe").validate(
        {
            submitHandler: function() {
                $("#form_contact .log").html('');
                if ($('#form_subscribe .bar').width() == 0)
                    $('#form_subscribe .bar').width('100%');
                $.post('ajax/subscribe', $('#form_subscribe').serialize(), function(data) {
                    $('input,button,textarea').addClass('disabled').attr('disabled', true);
                    var obj = JSON.parse(data);
                    $("#form_subscribe .log").html(obj.content);
                    $('.bar').hide().width('0');
                    if (obj.content)
                        $('input, button,textarea').removeClass('disabled').attr('disabled', false);
                    $('input:visible,textarea:visible').val('');
                    $container.masonry({
                        itemSelector: '.box',
                        isAnimated: true
                    });

                });
            }
        }
);
/*
 * ====================================================
 * Ajax save item
 * ====================================================
 */

$('#form_upload').validate({
    submitHandler: function() {
        $('.upAlert').hide();
        if (!$("#screen_shot").val() || !$('#upload_item').val()) {
            $('.upAlert').show();
        }
        else {
            $("#form_upload .log").html('');
            if ($('#form_upload .bar').width() == 0)
                $('#form_upload .bar').width('100%');
            $.post('ajax_online/save_item', $('#form_upload').serialize(), function(data) {
                $('input,button,textarea').addClass('disabled').attr('disabled', true);
                var obj = JSON.parse(data);
                $("#form_upload .log").html(obj.content);
                $('.bar').hide().width('0');
                if (obj.content)
                    $('input, button,textarea').removeClass('disabled').attr('disabled', false);
                $('input:visible,textarea:visible').val('');

            });
        }
    }
});
/*
 * ====================================================
 * End Ajax save item
 * ====================================================
 */


/*
 * ====================================================
 * Ajax FileUploader
 * ====================================================
 */
function createUploader_img() {
    var uploader = new qq.FileUploader({
        element: document.getElementById('file-uploader-img'),
        action: 'ajax_online/upload_image',
        allowedExtensions: ['png'],
        multiple: false,
        template: '<div class="qq-uploader row">' +
                '<div class="qq-upload-drop-area"><span>Drop files here to upload</span></div>' +
                '<div class="qq-upload-button btn span2">Upload a screen shot</div>' +
                '<ul class="qq-upload-list unstyled span3 row"></ul><input type="hidden" name="h"/>' +
                '</div>',
        fileTemplate: '<li>' +
                '<span class="qq-upload-file  alert alert-info span3"></span>' +
                '<span class="qq-upload-spinner "></span>' +
                '<span class="qq-upload-size  alert alert-success span3"></span>' +
                '<a class="qq-upload-cancel btn span1" href="#">Cancel</a>' +
                '<span class="qq-upload-failed-text alert alert-error span3"></span>' +
                '</li>',
        showMessage: function(message) {
            var alert = message;
            $('#screen_shot').val('');
            $('#file-uploader-img .qq-upload-file,#file-uploader-img  .qq-upload-size').remove();
            $('#file-uploader-img .qq-upload-failed-text').show().html(alert);
        },
        debug: false,
        onSubmit: function(id, fileName) {
            $('#screen_shot').val('');
            $('#file-uploader-img .qq-upload-list li').html('');
        },
        onCancel: function(id, fileName) {
            $('#screen_shot').val('');
        },
        onComplete: function(id, fileName, responseJSON) {
            var alert = ' - Image uploaded successfully';
            if (!responseJSON.success) {
                $('#screen_shot').val('');
                alert = 'Image must be 770x398, png & without browser border or modification';
                $('#file-uploader-img .qq-upload-file,#file-uploader-img .qq-upload-size').remove();
                $('#file-uploader-img .qq-upload-failed-text').show().html(alert);
            }
            else {
                $('#screen_shot').val(responseJSON.tmp);
                $('#file-uploader-img .qq-upload-size').append(alert);
            }
        }
    });
}



function createUploader_zip() {
    var uploader_zip = new qq.FileUploader({
        element: document.getElementById('file-uploader-zip'),
        action: 'ajax_online/upload_item',
        allowedExtensions: ['zip'],
        multiple: false,
        template: '<div class="qq-uploader row">' +
                '<div class="qq-upload-drop-area"><span>Drop files here to upload</span></div>' +
                '<div class="qq-upload-button btn  span2">Upload your item</div>' +
                '<ul class="qq-upload-list unstyled span3 row"></ul><input type="hidden" name="h"/>' +
                '</div>',
        fileTemplate: '<li>' +
                '<span class="qq-upload-file  alert alert-info span3"></span>' +
                '<span class="qq-upload-spinner "></span>' +
                '<span class="qq-upload-size  alert alert-success span3"></span>' +
                '<a class="qq-upload-cancel btn span1" href="#">Cancel</a>' +
                '<span class="qq-upload-failed-text alert alert-error span3"></span>' +
                '</li>',
        showMessage: function(message) {
            $('#upload_item').val('');
            var alert = message;
            $('#file-uploader-zip .qq-upload-file,#file-uploader-zip .qq-upload-size').remove();
            $('#file-uploader-zip .qq-upload-failed-text').show().html(alert);
        },
        debug: false,
        onSubmit: function(id, fileName) {
            $('#upload_item').val('');
            $('#file-uploader-zip .qq-upload-list li').html('');
        },
        onCancel: function(id, fileName) {
            $('#upload_item').val('');
        },
        onComplete: function(id, fileName, responseJSON) {
            var alert = ' - Item uploaded successfully';
            if (!responseJSON.success) {
                $('#upload_item').val('');
                alert = 'Must be a zip file';
                $('#file-uploader-zip .qq-upload-file,#file-uploader-zip .qq-upload-size').remove();
                $('.qq-upload-failed-text').show().html(alert);
            }
            else {
                $('#upload_item').val(responseJSON.tmp);
                $('#file-uploader-zip .qq-upload-size').append(alert);
            }
        }
    });
}
if ($('#file-uploader-zip').width()) {
    createUploader_zip();
    createUploader_img();
}
/*
 * ====================================================
 * End Ajax FileUploader
 * ====================================================
 */


$('#price').keyup(function() {
    var price = parseInt($("#price").val());
    if (price > 0)
        var fee = parseInt(price / 10) + 1;
    else
        fee = 0;
    if (!isNaN(price + fee))
        $("#marketprice").html(price + fee);
    else
        $("#marketprice").html("0");
});

var h = $(window).height() - ($('.navbar').height() + $('#prevFrame').height());
$('#iframe').css({
    'height': h
});
$(window).resize(function() {
    h = $(window).height() - ($('.navbar').height() + $('#prevFrame').height());
    $('#iframe').css({
        'height': h
    });
});
$('a').tooltip({
    placement: 'bottom'
});

$('.btn-payment').click(function() {
    $('#payment_form').submit();
    return false;
});

$('.btn-paypal').click(function() {
    var id = $(this).attr('rel');
    $.get('paypal/pay/' + id, function(data) {
        var obj = JSON.parse(data);
        $("body").append(obj.content);
    });
});

$('address').html(//'<a title="Postal address" href="javascript:void(0)"><i class="icon  icon-home"></i></a>'+
        //'&nbsp;Zied Hosni, 31 ibnou khaldoun ,Mourouj 1<br>'+
        //'Ben Arous - 2074, Tunisia<br>'+
        //'<a title="Phone" href="javascript:void(0)"><i class="icon  icon-signal"></i></a>&nbsp; (216) 97-620-495<br>'+
        '<a title="Email" href="javascript:void(0)"><i class="icon  icon-envelope"></i></a>&nbsp; contact@html5-ninja.com');


/*
 * ====================================================
 * Flattr button 
 * ====================================================
 */

(function() {
    var s = document.createElement('script'), t = document.getElementsByTagName('script')[0];
    s.type = 'text/javascript';
    s.async = true;
    s.src = 'http://api.flattr.com/js/0.6/load.js?mode=auto';
    t.parentNode.insertBefore(s, t);
})();

/*
 * ====================================================
 * facebook button 
 * ====================================================
 */
(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id))
        return;
    js = d.createElement(s);
    js.id = id;
    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=378424785574976";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

/*
 * ====================================================
 * twitter button 
 * ====================================================
 */
!function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (!d.getElementById(id)) {
        js = d.createElement(s);
        js.id = id;
        js.src = "//platform.twitter.com/widgets.js";
        fjs.parentNode.insertBefore(js, fjs);
    }
}(document, "script", "twitter-wjs");

/*
 * ====================================================
 * google+ button
 * ====================================================
 */
(function() {
    var po = document.createElement('script');
    po.type = 'text/javascript';
    po.async = true;
    po.src = 'https://apis.google.com/js/plusone.js';
    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(po, s);
})();

/*
 * ====================================================
 * stumble + button
 * ====================================================
 */
(function() {
    var li = document.createElement('script');
    li.type = 'text/javascript';
    li.async = true;
    li.src = ('https:' == document.location.protocol ? 'https:' : 'http:') + '//platform.stumbleupon.com/1/widgets.js';
    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(li, s);
})();
/*
 * ====================================================
 * share button show
 * ====================================================
 */

$(document).ready(function() {
    if ($('.homeShare').html())
        setTimeout($('.homeShare').fadeIn(2500), 3000);

    if ($('.shareTool').html())
        setTimeout($('.shareTool').fadeIn(2500), 3000);
});

/*
 * ====================================================
 * UserReport feedback
 * ====================================================
 */
/*var _urq = _urq || [];
 _urq.push(['initSite', '9f796615-0c32-4959-9da6-1a55a63c8558']);
 (function() {
 var ur = document.createElement('script');
 ur.type = 'text/javascript';
 ur.async = true;
 ur.src = 'http://sdscdn.userreport.com/userreport.js';
 var s = document.getElementsByTagName('script')[0];
 s.parentNode.insertBefore(ur, s);
 })();
 */
/*
 * ====================================================
 * google analytics
 * ====================================================
 */
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-32531891-1']);
_gaq.push(['_trackPageview']);

(function() {
    var ga = document.createElement('script');
    ga.type = 'text/javascript';
    ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(ga, s);
})();