let rides = [];
fetch('http://localhost:12932/ride')
    .then(x => x.json())
    .then(y => {
        rides = y;
        console.log(rides);
        display();
    });

function display() {
    rides.forEach(t => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.rid + "</td><td>"
            + t.distance + "</td><td>";

        //console.log(t.Name)
    })
}