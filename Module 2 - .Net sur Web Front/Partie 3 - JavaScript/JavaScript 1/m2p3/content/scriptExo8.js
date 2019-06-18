//On crée la variable age
var age;
//On crée notre fonction
function areYouMajor() {
    //On stoke la valeur de l'inpute age
    age = document.getElementById('age').value;
    //On verifi quil a bien entré un age valide
    if (isNaN(age) || age > 120 || age <= 0) {
        alert('Âge incorrecte');
    } else {
        //On vérifie si il est majeur
        if (age >= 18) {
            alert('Vous êtes majeur');
        } else {
            alert('Vous êtes mineur');
        }
    }
}