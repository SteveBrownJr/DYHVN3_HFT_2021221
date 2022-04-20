let locomotives = [];

fetch('http://localhost:38193/Locomotive')
    .then(x => x.json())
    .then(y => {
        locomotives = y;
        console.log(locomotives);
        display();
    });

function display() {
    locomotives.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.locomotive_Id + "</td><td>"
        + t.name + "</td><td> "
        + t.type + "</td><td> "
        + t.staff + " fő</td><td> "
        + t.starting_Torque + " kN </td><td> "
        + t.load + " tonna"
        + "</td></tr>"
    });
}