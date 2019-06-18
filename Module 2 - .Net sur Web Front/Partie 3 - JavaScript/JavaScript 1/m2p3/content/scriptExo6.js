//On crée les variables
var firstNumber;
var secondNumber;
//On crée la fonction
function modulo() {
    //On stocke les valeur des input
    firstNumber = document.getElementById("firstNumber").value;
    secondNumber = document.getElementById("secondNumber").value;
    //On verifie que l'on a bien entrée des nombre
    if (isNaN(firstNumber) || isNaN(secondNumber) || secondNumber == 0) {
        alert('Saisie Incorrecte');
    } else {
        //On affiche le modulo de la division des deux nombres
        alert("Le reste de " + firstNumber + " / " + secondNumber + " est de " + firstNumber % secondNumber);
    }
};

