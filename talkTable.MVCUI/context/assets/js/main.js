$(document).ready(function () {
    var userAgent = window.navigator.userAgent,
        platform = window.navigator.platform,
        macosPlatforms = ['Macintosh', 'MacIntel', 'MacPPC', 'Mac68K'],
        windowsPlatforms = ['Win32', 'Win64', 'Windows', 'WinCE'],
        iosPlatforms = ['iPhone', 'iPad', 'iPod'],
        os = null;
    if (macosPlatforms.indexOf(platform) !== -1) {
        os = 'macOS';
    } else if (iosPlatforms.indexOf(platform) !== -1) {
        os = 'ios';
    } else if (windowsPlatforms.indexOf(platform) !== -1) {
        os = 'windows';
    } else if (/Android/.test(userAgent)) {
        os = 'android';
    } else if (!os && /Linux/.test(platform)) {
        os = 'linux';
    }
    $('html').addClass(os);
    if (navigator.userAgent.indexOf('Safari') != -1 && navigator.userAgent.indexOf('Chrome') == -1) {
        $('html').addClass('safari');
    }

    $('.mobile-menu-area ul li:not(.sub) > a').bind('click', function () {
        if($(this).parents('li').hasClass('go-section')){
            $('body.mobile-menu-open').removeClass('mobile-menu-open');
            $('.mobile-menu-area.open').removeClass('open');
            $('.overflow').removeClass('active');
            $('html, body').removeClass('no-scroll');
            if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
                var target = $(this.hash);
                target = target.length ? target : $('[id=' + this.hash.slice(1) +']');
                if (target.length) {
                    $('html,body').animate({
                        scrollTop: target.offset().top
                    }, 1000);
                    return false;
                }
            }
        }
    }); 
    $('a.go-anim').bind('click', function () {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[id=' + this.hash.slice(1) +']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        }
    }); 
    $('.mobile-menu-area ul li.sub > a').bind('click', function () {
        $(this).parent().addClass('open');
        $(this).parent().parent().addClass('opened');
        $(this).parent().parents('.sub-menu').addClass('opened');
        return false;
    });
    $('.mobile-menu-area ul li.sub .sub-menu .title > a').bind('click', function () {
        $(this).parent().parent().parent().removeClass('open');
        $(this).parent().parent().removeClass('opened');
        $(this).parent().parent().parent().parent().removeClass('opened');
        $(this).parent().parent().parent().parent().parent().removeClass('opened');
        return false;
    });
    $('.mobile-menu-btn').bind('click', function () {
        var $this = $(this);
        $('body').toggleClass('mobile-menu-open');
        if ($('.mobile-menu-area').hasClass('open') == false) {
            $('html,body').animate({
                scrollTop: $('.mobile-menu-area').offset().top
            }, 100);
        }
        $('.mobile-menu-area').toggleClass('open');
        $('.overflow').toggleClass('active');
        $('html, body').toggleClass('no-scroll');
        if($('.mobile-menu-area').hasClass('no-search')){
            $('.mobile-menu-area .menu').css({
                'height': $(window).height(),
                'overflow': 'auto',
            });
        }else{
            $('.mobile-menu-area .menu').css({
                'height': $(window).height() - 72,
                'overflow': 'auto',
            });
        }
        return false;
    });
    $(window).resize(function () {
        AOS.refreshHard();
        if ($(window).width() > 993) {
            $('body.mobile-menu-open').removeClass('mobile-menu-open');
            $('.mobile-menu-area.open').removeClass('open');
            $('.overflow').removeClass('active');
            $('html, body').removeClass('no-scroll');
        }
    });
    if ($('.mask_phone').length > 0) {
        $('.mask_phone').mask('(000) 000 00 00', {
            placeholder: "(___) ___ __ __"
        });
    }
    if ($('input.date').length > 0) {
        $('input.date').datetimepicker({
            locale: 'tr',
            format: 'DD/M/YYYY'
        });
    }
    if($(window).scrollTop() > 180){
        $('header').addClass('scrolled');
    }else{
        $('header').removeClass('scrolled');
    }
    $(window).scroll(function(){
        if($(window).scrollTop() > 180){
            $('header').addClass('scrolled');
        }else{
            $('header').removeClass('scrolled');
        }
    });
    $('#phone-int .ints > div').hover(function(){
        $(this).addClass('open');
    }, function(){
        $(this).removeClass('open');
    });
    $('header a').click(function() {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[id=' + this.hash.slice(1) +']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        }
    });
});
