
function getRndInteger(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

mb = { type: "Motherboard", name: "Name1", detail: "Detail1", price: "30000" }, cpu = { type: "CPU", name: "Name1", detail: "Detail1", price: "50000" },
    ram = { type: "RAM", name: "Name1", detail: "Detail1", price: "20000" }, gpu = { type: "GPU", name: "Name1", detail: "Detail1", price: "100000" },
    hdd = { type: "HDD", name: "Name1", detail: "Detail1", price: "40000" }, monitor = { type: "Monitor*", name: "Name1", detail: "Detail1", price: "90000" },
    mouse = { type: "Mouse*", name: "Name1", detail: "Detail1", price: "25000" }, kb = { type: "Keyboard*", name: "Name1", detail: "Detail1", price: "45000" }
types = ["Motherboard", "CPU", "RAM", "GPU", "HDD", "Monitor*", "Mouse*", "Keyboard*"]
reszek = [mb, cpu, ram, gpu, hdd, monitor, mouse, kb]
for (let i = 0; 200 - reszek.length; i++) {
    t = types[getRndInteger(0, 7)]
    n = "Name" + getRndInteger(100, 999)
    d = "Detail" + getRndInteger(100, 999)
    p = getRndInteger(10000, 100000)
    temp = { type: t, name: n, detail: d, price: p }
    reszek.push(temp)
}

for (let i = 0; i < reszek.length; i++) {
    switch (reszek[i].type) {
        case "Motherboard":
            document.getElementById("mb").innerHTML += `<option value="${reszek[i].price}">${reszek[i].name}</option>`
            break
        case "CPU":
            document.getElementById("cpu").innerHTML += `<option value="${reszek[i].price}">${reszek[i].name}</option>`
            break
        case "RAM":
            document.getElementById("ram").innerHTML += `<option value="${reszek[i].price}">${reszek[i].name}</option>`
            break
        case "GPU":
            document.getElementById("graf").innerHTML += `<option value="${reszek[i].price}">${reszek[i].name}</option>`
            break
        case "HDD":
            document.getElementById("hdd").innerHTML += `<option value="${reszek[i].price}">${reszek[i].name}</option>`
            break
        case "Monitor*":
            document.getElementById("monitor").innerHTML += `<option value="${reszek[i].price}">${reszek[i].name}</option>`
            break
        case "Mouse*":
            document.getElementById("m").innerHTML += `<option value="${reszek[i].price}">${reszek[i].name}</option>`
            break
        case "Keyboard*":
            document.getElementById("kb").innerHTML += `<option value="${reszek[i].price}">${reszek[i].name}</option>`
            break
    }
}

function teljesAr() {
    document.getElementById("teljesArIro").innerHTML = "Teljes ár: "
    var ar = 0
    ar += Number(document.getElementById("mb").value)
    ar += Number(document.getElementById("cpu").value)
    ar += Number(document.getElementById("ram").value)
    ar += Number(document.getElementById("graf").value)
    ar += Number(document.getElementById("hdd").value)
    ar += Number(document.getElementById("monitor").value)
    ar += Number(document.getElementById("m").value)
    ar += Number(document.getElementById("kb").value)
    document.getElementById("teljesArIro").innerHTML += ar + " Ft"
    if (document.getElementById("mb").value > 0)
        document.getElementById("mbar").innerHTML = document.getElementById("mb").value + " Ft"
    if (document.getElementById("cpu").value > 0)
        document.getElementById("cpuar").innerHTML = document.getElementById("cpu").value + " Ft"
    if (document.getElementById("ram").value > 0)
        document.getElementById("ramar").innerHTML = document.getElementById("ram").value + " Ft"
    if (document.getElementById("graf").value > 0)
        document.getElementById("grafar").innerHTML = document.getElementById("graf").value + " Ft"
    if (document.getElementById("hdd").value > 0)
        document.getElementById("hddar").innerHTML = document.getElementById("hdd").value + " Ft"
    if (document.getElementById("monitor").value > 0)
        document.getElementById("monitorar").innerHTML = document.getElementById("monitor").value + " Ft"
    if (document.getElementById("m").value > 0)
        document.getElementById("mar").innerHTML = document.getElementById("m").value + " Ft"
    if (document.getElementById("kb").value > 0)
        document.getElementById("kbar").innerHTML = document.getElementById("kb").value + " Ft"
}

function megrendeles() {
    document.getElementById("mbL").style.color = "black"
    document.getElementById("cpuL").style.color = "black"
    document.getElementById("ramL").style.color = "black"
    document.getElementById("grafL").style.color = "black"
    document.getElementById("hddL").style.color = "black"
    if (document.getElementById("mb").value == 0 ||
        document.getElementById("cpu").value == 0 ||
        document.getElementById("ram").value == 0 ||
        document.getElementById("graf").value == 0 ||
        document.getElementById("hdd").value == 0) {
        if (document.getElementById("mb").value == 0) { document.getElementById("mbL").style.color = "red" }
        if (document.getElementById("cpu").value == 0) { document.getElementById("cpuL").style.color = "red" }
        if (document.getElementById("ram").value == 0) { document.getElementById("ramL").style.color = "red" }
        if (document.getElementById("graf").value == 0) { document.getElementById("grafL").style.color = "red" }
        if (document.getElementById("hdd").value == 0) { document.getElementById("hddL").style.color = "red" }
        document.getElementById("siker").innerHTML="Válasszon ki egyet a kötelező elemek közül!"
    }
    else
    document.getElementById("siker").innerHTML="Megrendelés elküldve!"
}