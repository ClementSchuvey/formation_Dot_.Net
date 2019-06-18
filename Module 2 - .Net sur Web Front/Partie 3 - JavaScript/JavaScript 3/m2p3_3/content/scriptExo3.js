/*Fonction qui permet de changer la couleur du text 
 * Démarée lorsqu'on click sur les bouttons de couleur
 * Le paramètre classElement récupére le tableaux des class, de l'élément sur le quelle on a cliqué*/
function changeColorText(classElement) {
    //Si l'indice 1 du tableau des class est égale à green on change la couleur du text en vert
    if (classElement[1] == "green") {
        document.getElementById('text').style.color = "green";
    //Si l'indice 1 du tableau des class est égale à red on change la couleur du text en rouge
    } else if (classElement[1] == "red") {
        document.getElementById('text').style.color = "red";
    //Si l'indice 1 du tableau des class est égale à blue on change la couleur du text en bleu
    } else if (classElement[1] == "blue") {
        document.getElementById('text').style.color = "blue";
    }
}