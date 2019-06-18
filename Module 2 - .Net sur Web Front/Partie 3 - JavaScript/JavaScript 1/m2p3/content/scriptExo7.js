//On crée nos variables
var shoeSize;
var yearBirth;
var result;
var dateNow = new Date();
var yearsNow = dateNow.getFullYear();
console.log(yearsNow);
//On crée notre fonction calcul qui fait tout les calcule et retourne le resultat
function calcul() {
    //On stocke les valeurs des input dans des variables
    shoeSize = document.getElementById('shoeSize').value;
    yearBirth = document.getElementById('yearOfBirth').value;
    if (isNaN(shoeSize) || isNaN(yearBirth) || shoeSize > 59 || yearBirth > yearsNow || shoeSize < 15 || yearBirth < 1903) {
        result = "Saisie Incorrecte";
    } else {
        //On fait les calcules
        result = shoeSize * 2;
        result += 5;
        result *= 50;
        result -= yearBirth;
        result += 1769;
    }
    return result;
}