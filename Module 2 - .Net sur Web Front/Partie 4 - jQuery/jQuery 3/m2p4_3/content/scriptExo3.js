var numberSearch = Math.floor(Math.random() * (0 + 100) + 1);
var userNumber;
console.log(numberSearch);
$('#testNumber').click(function () {
    userNumber = $('#userNumber').val();
    if ($.isNumeric(userNumber)){
        if (userNumber <= 100 && userNumber >= 0) {
            if (userNumber > numberSearch) {
                alert('c\'est moins !');
            } else if (userNumber < numberSearch) {
                alert('c\'est plus !');
            }
            else if (userNumber == numberSearch) {
                alert('T\'as gagner !');
            }
        } else {
            alert('Ce nombre n\'est pas entre 0 et 100');
        }
    } else {
        alert('saisie incorrecte');
    }
});