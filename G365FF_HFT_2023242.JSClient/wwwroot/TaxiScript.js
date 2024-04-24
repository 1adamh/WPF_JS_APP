let taxis = [];
fetch('http://localhost:12932/taxi')
    .then(x => x.json())
    .then(y => {
        taxis = y;
        console.log(taxis);
        display();
    });

function display() {
    taxis.forEach(t => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.tid + "</td><td>"
            + t.name + "</td><td>" ;

        //console.log(t.Name)
    })
}

function createtaxi() {
    let name = document.getElementById('taxiname').value;
    fetch('http://localhost:12932/taxi', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}