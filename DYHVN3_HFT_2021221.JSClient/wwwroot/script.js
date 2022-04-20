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

function CreatLocomotive() {
    let name = document.getElementById('locomotivename').value;
    let type = document.getElementById('locomotivetype').value;
    let startingtorque = document.getElementById('locomotivestartingtorque').value;
    let staff = document.getElementById('locomotivestaff').value;
    fetch('https://jsondatabase-7c304-default-rtdb.europe-west1.firebasedatabase.app/orders.json', {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: name,
                type: type,
                starting_Torque: startingtorque,
                staff: staff
            }),
        })
        .then(response => response.json())
        .then(data => {
        console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}