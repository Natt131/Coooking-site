
const xhttp = new XMLHttpRequest();
let cd;
xhttp.onload = function () {
    const xmlDoc = xhttp.responseXML;
    cd = xmlDoc.getElementsByTagName("SITE");
    loadCD();
}

xhttp.open("GET", "../ajax/catalog.xml");
xhttp.send();

let n = 0;
let len = cd.length;
console.log( "len1");
console.log(cd.length + "lenzz");
console.log("len2");
function loadCD() {
    console.log(cd.length + "len");
    let name = "";
    for (let i = 0; i < cd.length; i++) {
        name += " <h3 onclick='displayCD(" + i + ")'>" + cd[i].getElementsByTagName("TITLE")[0].childNodes[0].nodeValue +"</h3>";
    }
    document.getElementById("load").innerHTML = name;
}

function displayCD(i) {
    document.getElementById("showCD").innerHTML = 
        "Название: " +
        cd[i].getElementsByTagName("TITLE")[0].childNodes[0].nodeValue+"<br/>"
       + "Описание: " +
    cd[i].getElementsByTagName("DESCRIPTION")[0].childNodes[0].nodeValue + "<br/>" +
        "Сайт: " +
        cd[i].getElementsByTagName("URL")[0].childNodes[0].nodeValue;
}

function next() {
    if (n < cd.length - 1) {
        n++;
        displayCD(n);
    }
}

function previous() {
    console.log("prev");
    if (n > 0) {
        n--;
        displayCD(n);
    }
}