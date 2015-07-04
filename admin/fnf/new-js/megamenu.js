jQuery.fn.megamenu = function(e) {
    function r() {
        jQuery(".megamenu").find("li, a").unbind();
        if (window.innerWidth <= 768) {
            o();
            s();
            if (n == 0) {
                jQuery(".megamenu > li:not(.showhide)").hide(0)
            }
        } else {
            u();
            i()
        }
    }

    function i() {
        jQuery(".megamenu li").bind("mouseover", function () {
            scrollMenu();
            console.log('1');
            jQuery(this).children(".dropdown, .megapanel").stop().fadeIn(t.interval)
        }).bind("mouseleave", function() {
            jQuery(this).children(".dropdown, .megapanel").stop().fadeOut(t.interval)
        })
    }

    function s() {
        jQuery(".megamenu > li > a").bind("click", function(e) {
            if (jQuery(this).siblings(".dropdown, .megapanel").css("display") == "none") {
                jQuery(this).siblings(".dropdown, .megapanel").slideDown(t.interval);
                jQuery(this).siblings(".dropdown").find("ul").slideDown(t.interval);
                n = 1
            } else {
                jQuery(this).siblings(".dropdown, .megapanel").slideUp(t.interval)
            }
        })
    }
    function o() {
        jQuery(".megamenu > li.showhide").show(0);
        jQuery(".megamenu > li.showhide").bind("click", function() {
            if (jQuery(".megamenu > li").is(":hidden")) {
                jQuery(".megamenu > li").slideDown(300)
            } else {
                jQuery(".megamenu > li:not(.showhide)").slideUp(300);
                jQuery(".megamenu > li.showhide").show(0)
            }
        })
    }
    function u() {
        jQuery(".megamenu > li").show(0);
        jQuery(".megamenu > li.showhide").hide(0)
    }
    var t = {
        interval: 50
    };
    var n = 0;
    jQuery(".megamenu").prepend("<li class='showhide'><span class='title'>MENU</span><span class='icon1'></span><span class='icon2'></span></li>");
    r();
    jQuery(window).resize(function() {
        r()
    })
}