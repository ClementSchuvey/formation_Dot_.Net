//Fonction qui va verifier les 2 mdp, déclenchée au click sur le boutton verifier
function verifyPassword() {
    //Si les 2 input n'ont pas les même valeur
    if (document.getElementById('password').value != document.getElementById('confirmPassword').value) {
        //On change la bordure des input en red
        document.getElementById('password').style.border = "1px solid red";
        document.getElementById('confirmPassword').style.border = "1px solid red";
    } else {
        //Sinon on met la bordure des input en vert
        document.getElementById('password').style.border = "1px solid green";
        document.getElementById('confirmPassword').style.border = "1px solid green";
    }
}