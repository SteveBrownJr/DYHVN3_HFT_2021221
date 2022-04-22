let stations = [];
let connection = null;
getdata();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:38193/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StationCreated", (user, message) => {
        console.log(user);
        console.log(message);
        location.reload();
    });
    connection.on("StationDeleted", (user, message) => {
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
    setupSignalR()
    fetch('http://localhost:38193/Station')
        .then(x => x.json())
        .then(y => {
            stations = y;
            console.log(stations);
            display();
        });
}


function display() {
    stations.forEach(s => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + s.station_Id + "</td><td>"
            + s.name+ "</td><td>"
            + s.locomotive_Id + "</td><td>" +
            + s.x_cordinate + "</td><td>" +
            + s.y_cordinate + "</td><td>" +
            `<button type="button" onclick="RemoveStation(${s.station_Id})"> Delete </button>`
            + "</td></tr>"
    });
}

function RemoveStation(id) {
    fetch('http://localhost:38193/Station/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
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

function CreateStation() {
    let sname = document.getElementById('stationname').value;
    let l_id = document.getElementById('Locomotive_id').value;
    let sX = document.getElementById('X').value;
    let sY = document.getElementById('Y').value;
    fetch('http://localhost:38193/Station', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                locomotive_Id: l_id,
                name: sname,
                x_cordinate: sX,
                y_cordinate: sY
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