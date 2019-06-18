//function changePicture(idMyElement) {
//    if (document.getElementById(idMyElement).src.substr(-6,2) == '_2') {
//        document.getElementById(idMyElement).src = 'images/' + idMyElement + '.jpg';
//    } else {
//        document.getElementById(idMyElement).src = 'images/' + idMyElement + '_2.jpg';
//    }
//}

//Je déclare ma fonction changePictureMouseOver avec le paramètre idMyElement
function changePictureMouseOver(idMyElement) {
    //Je change la src de l'élément possédant l'id sotcker dans le paramètre
    document.getElementById(idMyElement).src = 'images/' + idMyElement + '_2.jpg';
}
function changePictureMouseOut(idMyElement) {
    document.getElementById(idMyElement).src = 'images/' + idMyElement + '.jpg';
}