// myQue Scripts - Requires jQuery and Jquery Tools - Tooltips

$(function () {
    // select all desired input fields and attach tooltips to them
    $(".artist_list").tooltip({

        // place tooltip on the right edge
        position: ['center', 'right'],

        // a little tweaking of the position
        offset: [-12, 33],

        // use a simple show/hide effect
        effect: 'fade',
        fadeInSpeed: 500,
        fadeOutSpeed: 500,

        // custom opacity setting
        opacity: 0.7
    });
    // Tooltip trigger
    $("#trigger").tooltip();
});