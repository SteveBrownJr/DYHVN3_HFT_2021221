fetch('http://localhost:38193/Locomotive')
    .then(x => x.json())
    .then(y => console.log(y));