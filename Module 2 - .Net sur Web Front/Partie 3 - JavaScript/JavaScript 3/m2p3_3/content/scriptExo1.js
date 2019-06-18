//On crée notre fonction modifyBorder() qui s'active quand on passe notre souris sur l'image ou on sort de l'image
function modifyBorder() {
    //Si la bordure est égale à "3px solid red"
    if (document.getElementById('image1').style.border == "3px solid red") {
        //On la retire la bordure
        document.getElementById('image1').style.border = "none";
    } else {
        //On affiche la bordure
        document.getElementById('image1').style.border = "3px solid red";
    }
}