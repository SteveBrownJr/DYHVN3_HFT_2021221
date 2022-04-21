let locomotives = [];

getdata();

async function getdata() {
    fetch('http://localhost:38193/Locomotive')
        .then(x => x.json())
        .then(y => {
            locomotives = y;
            console.log(locomotives);
            display();
        });
}
function display() {
    locomotives.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.locomotive_Id + "</td><td>"
        + t.name + "</td><td> "
        + t.type + "</td><td> "
        + t.staff + " fő</td><td> "
        + t.starting_Torque + " kN </td><td> "
        + t.load + " tonna </td><td>" +
        `<button type="button" onclick="RemoveLocomotive(${t.locomotive_Id})"> Delete </button>`
        + "</td></tr>"
    });
}

function RemoveLocomotive(id) {
    fetch('http://localhost:38193/Locomotive/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            location.reload();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function CreateLocomotive() {
    let lname = document.getElementById('locomotivename').value;
    let ltype = document.getElementById('locomotivetype').value;
    let lstartingtorque = document.getElementById('locomotivestartingtorque').value;
    let lstaff = document.getElementById('locomotivestaff').value;
    fetch('http://localhost:38193/Locomotive', {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: lname,
                type: ltype,
                starting_Torque: lstartingtorque,
                staff: lstaff
            }),
        })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            location.reload();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}