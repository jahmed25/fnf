if ($(window).width() > 1024) {
  //  sc()
}
function sc()
{
    var top = jQuery(this).scrollTop();
    var filter = jQuery('#floating_filter');
    var filter_height = jQuery('#floating_filter').outerHeight(true);
    //var listing_height = jQuery('.listing_right').height();
    var threshold_start = jQuery('#filter_float_threshold_start').offset().top;
    var threshold_end = jQuery('#filter_float_threshold_end').position().top - 236;

    if (top <= threshold_start) {
        setFilterPosition('static', 0);
    } else if (top > threshold_start && top < ((threshold_end + 75) - filter_height)) {
        setFilterPosition('fixed', 30);
    } else {
        var pos = (((threshold_end + 70) - filter_height) - top);
        setFilterPosition('fixed', pos);
    }
    $(function () {
        $('.scroll-pane').jScrollPane();
    });
}
jQuery(window).on('scroll', function () {
    if ($(window).width() > 1024) {
        sc();
    }
    else {
        $('#floating_filter').css('position', 'static');
    }
 });



function setFilterPosition(pos, top) {
    jQuery('#floating_filter').css({
        'top': top,
        'position': pos,
        'width':'170px'
    });
}
