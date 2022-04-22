let locomotives = [];
let connection = null;
let mostpowerfultrain;
let weakesttrain;
let longesttrain;
let voltmar;
getdata();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:38193/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("LocomotiveCreated", (user, message) => {
        console.log(user);
        console.log(message);
        location.reload();
    });
    connection.on("LocomotiveDeleted", (user, message) => {
        console.log(user);
        console.log(message);
        location.reload();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    voltmar = false;
    setupSignalR()
    fetch('http://localhost:38193/Train/LongestTrain/')
        .then(x => x.json())
        .then(y => {
            longesttrain = y;
            display2();
        });

    fetch('http://localhost:38193/Train/MostPowerFulLocomotive/')
        .then(x => x.json())
        .then(y => {
            mostpowerfultrain = y;
            display2();
        });

    fetch('http://localhost:38193/Train/WeakestLocomotive/')
        .then(x => x.json())
        .then(y => {
            weakesttrain = y;
            display2();
        });

    fetch('http://localhost:38193/Locomotive')
        .then(x => x.json())
        .then(y => {
            locomotives = y;
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
function display2() {
    if (!voltmar) {
    document.getElementById('noncrud').innerHTML=""
    document.getElementById('noncrud').innerHTML +=
        "<p>A legerősebb mozdony: Id:"
        + mostpowerfultrain.locomotive_Id + " Név: " + mostpowerfultrain.name;
    document.getElementById('noncrud').innerHTML +=
        "<p>A leggyengébb mozdony: Id:"
        + weakesttrain.locomotive_Id + " Név: " + weakesttrain.name;
    document.getElementById('noncrud').innerHTML +=
        "<p>A leghosszabb vonat: Id:"
        + longesttrain.locomotive_Id + " Név: " + longesttrain.name;
    }
    voltmar = true;
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