// Je lance tous mes scripts lorsque ma page html est chargée
$(document).ready(function () {
    //Je déclare une variable qui va stocker la valeur de l'élèment possèdant l'id showNumber
    var number = $('#showNumber').val();
    //Lorsque je clique sur l'élément possèdant l'id addNumber
    $('#addNumber').click(function () {
        //J'incrémente de 1 ma variable number 
        number++;
        //Je change la valeur de showNumber par la valeur de number
        $('#showNumber').attr('value', number);
    });
    //Lorsque je clique sur l'élément possèdant l'id takeNumber
    $('#takeNumber').click(function () {
        //Je décrémente de 1 ma variable number 
        number--;
        //Je change la valeur de showNumber par la valeur de number
        $('#showNumber').val(number);
    });
});