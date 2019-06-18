//Je sotcke mon boutton RAZ
var buttonRaz = document.getElementById('submit');
//Evenement quand je click sur le boutton
buttonRaz.addEventListener("click", function () {
    //Je mes la valeur des input vide
    document.getElementById('lastname').value = '';
    document.getElementById('firstname').value = '';
    document.getElementById('city').value = '';
});
