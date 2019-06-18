var number = $('#showNumber').attr('value');
$('#addNumber').click(function () {
    number++;
    $('#showNumber').attr('value', number);
});