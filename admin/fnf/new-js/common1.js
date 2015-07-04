$(document).ready(function () {
    //open popup
    $("#log").click(function () {
        $("#overlay_form").fadeIn(1000);
        $(".background_overlay").fadeIn(500);
        positionPopup();
    });

    //close popup
    $("#close, .background_overlay").click(function (e) {

        $("#overlay_form").fadeOut(500);
        $(".background_overlay").fadeOut(500);
    });
    $(window).bind('resize', positionPopup);

    $("[WL]").live('click', function () {
        var sku = $(this).attr('sku');
        var param = { action: 'removeFromWL', sku: sku };
        $.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx', data: param })
			    .success(function (msg) {
			        $("[name='WLContainer']").html($(msg).filter('#mini_cart_block').html());
			    });
    });
    $("[cart]").live('click', function () {
        var sku = $(this).attr('sku');
        var param = { action: 'removeFromCart', sku: sku };
        $.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx', data: param })
			        .success(function (msg) {
			            $("[name='cartContainer']").html($(msg).filter('#mini_cart_block').html());
			        });
    });
    function reloadWL() {
        jQuery.ajax({ method: 'POST', url: path + 'sfloor/pages/ReloadWL.aspx' })
			.success(function (msg) {
			    if (jQuery("[name='WLContainer']").length > 0) {
			        jQuery("[name='WLContainer']").html(jQuery(msg).filter('#mini_cart_block').html());
			    } else {
			        window.top.jQuery("[name='WLContainer']").html(jQuery(msg).filter('#mini_cart_block').html());
			    }
			    jQuery("#wlNotificationInfo").show();
			});
    }

    //maintain the popup at center of the page when browser resized
    $("a[name='saveLater']").live('click', function () {
        alert(1);
        var sku1 = $(this).attr('sku');
        var inner = $(this).attr('inner')
        $.ajax({ method: 'POST', url: path + 'sfloor/pages/AjaxService.aspx?action=addFav', data: { sku: sku1} })
			.success(function (msg) {
			    reloadWL();
			});

    });

});
//position the popup at the center of the page
function positionPopup() {
    if (!$("#overlay_form").is(':visible')) {
        return;
    }
    $("#overlay_form").css({
        left: ($(window).width() - $('#overlay_form').width()) / 2,
        top: ($(window).width() - $('#overlay_form').width()) / 7,
        position: 'absolute'
    });
}

$(document).ready(function () {
    //open popup
    $("a[pop]").live('click', function () {
        $('#quickViewObj').attr("data", path + "sfloor/pages/QuickView.aspx?sku=" + $(this).attr('pop'));
        $("#overlay_form_quick").fadeIn(1000);
        $(".background_overlay_quick").fadeIn(500);
        positionPopupQuick();
    });

    //close popup
    $("#closequickview, .background_overlay_quick").click(function () {
        $("#overlay_form_quick").fadeOut(500);
        $(".background_overlay_quick").fadeOut(500);
    });
    $(window).bind('resize', positionPopup);
    //maintain the popup at center of the page when browser resized
});
//position the popup at the center of the page
function positionPopupQuick() {
    if (!$("#overlay_form_quick").is(':visible')) {
        return;
    }
    $("#overlay_form_quick").css({
        left: ($(window).width() - $('#overlay_form_quick').width()) / 2,
        top: ($(window).width() - $('#overlay_form_quick').width()) / 7,
        position: 'absolute'
    });
}

$(document).ready(function () {
    //open popup
    $('#checkoutlogin').click(function () {
        $("#checkout_overlay_form").fadeIn(1000);
        $(".checkout_background_overlay").fadeIn(500);
        checkout_positionPopup();
    });
    //close popup
    $("#close, .checkout_background_overlay").click(function () {
        $("#checkout_overlay_form").fadeOut(500);
        $(".checkout_background_overlay").fadeOut(500);
    });
    $(window).bind('resize', checkout_positionPopup);
});
//position the popup at the center of the page
function checkout_positionPopup() {
    if (!$("#checkout_overlay_form").is(':visible')) {
        return;
    }
    $("#checkout_overlay_form").css({
        left: ($(window).width() - $('#checkout_overlay_form').width()) / 2,
        top: ($(window).width() - $('#checkout_overlay_form').width()) / 7,
        position: 'absolute'
    });
}

$(document).ready(function () {
    //open popup
    $('#fgt_clk_hre').click(function () {
        $("#overlay_form").fadeOut(500);
        $(".background_overlay").fadeOut(500);
        $("#checkout_overlay_form").fadeOut(500);

        $(".checkout_background_overlay").fadeOut(500);
        $("#fgt_overlay_form").fadeIn(1000);
        $(".fgt_background_overlay").fadeIn(500);
        fgt_positionPopup();
    });
    $('#logsign').click(function () {
        $("#fgt_overlay_form").fadeOut(1000);
        $(".fgt_background_overlay").fadeOut(500);
        $("#checkout_overlay_form").fadeIn(500);

        $(".checkout_background_overlay").fadeIn(500);
       
        $("#overlay_form").fadeIn(500);
        $(".background_overlay").fadeIn(500);
        fgt_positionPopup();
    });
    //close popup
    $("#fgt_close, .fgt_background_overlay").click(function () {
        $("#fgt_overlay_form").fadeOut(500);
        $(".fgt_background_overlay").fadeOut(500);
    });
    $(window).bind('resize', fgt_positionPopup);
});
//position the popup at the center of the page
function fgt_positionPopup() {
    if (!$("#fgt_overlay_form").is(':visible')) {
        return;
    }
    $("#fgt_overlay_form").css({
        left: ($(window).width() - $('#fgt_overlay_form').width()) / 2,
        top: ($(window).width() - $('#fgt_overlay_form').width()) / 7,
        position: 'absolute'
    });
}
