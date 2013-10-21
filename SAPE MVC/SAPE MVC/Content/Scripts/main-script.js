jQuery(document).ready(function ($) {
    //Resize divs to fit screen
    function resizeDivs() {
        var height = $(window).attr('innerHeight') - 70;
        $("#main-content").attr('style', 'height:' + height + 'px');
    };

    //On window resize change div sizes
    $(window).on('resize', function () {
        resizeDivs();
    });

    resizeDivs();
});