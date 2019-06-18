var yearBirth = prompt("Quelle est ton année de naissance ?");

if (isNaN(yearBirth)) {
    alert('Saisie Incorrecte');
} else {
    if ((yearBirth % 4 == 0) && ((yearBirth % 100 != 0) || (yearBirth % 400 == 0))) {
        document.getElementById('youAreBisex').style.display = 'block';
    } else {
        document.getElementById('youNotBisex').style.display = 'block';
    }
}