var heightRectangle;
$('#upHeight').click(function () {
    heightRectangle = $('#rectangle').height();
    heightRectangle += 10;
    if (heightRectangle <= 100) {
        $('#rectangle').height(heightRectangle);
    } else {
        $('#rectangle').height('10px');
    }
    console.log(heightRectangle);
});
$('#greenRectangle').click(function () {
    $('#rectangle').css('background-color', 'green');
});
$('#resetColor').click(function () {
    $('#rectangle').css('background-color', 'black');
});
$('#hideRectangle').click(function () {
    $('#rectangle').hide();
});
$('#showRectangle').click(function () {
    $('#rectangle').show();
});
