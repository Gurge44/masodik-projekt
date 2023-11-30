
function getRndInteger(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

mb = { type: "Motherboard", name: "Name1", detail: "Detail1", price: "30000" }, cpu = { type: "CPU", name: "Name1", detail: "Detail1", price: "50000" },
    ram = { type: "RAM", name: "Name1", detail: "Detail1", price: "20000" }, gpu = { type: "GPU", name: "Name1", detail: "Detail1", price: "100000" },
    hdd = { type: "HDD", name: "Name1", detail: "Detail1", price: "40000" }, monitor = { type: "Monitor*", name: "Name1", detail: "Detail1", price: "90000" },
    mouse = { type: "Mouse*", name: "Name1", detail: "Detail1", price: "25000" }, kb = { type: "Keyboard*", name: "Name1", detail: "Detail1", price: "45000" }
types = ["Motherboard", "CPU", "RAM", "GPU", "HDD", "Monitor*", "Mouse*", "Keyboard*"]
reszek = [mb, cpu, ram, gpu, hdd, monitor, mouse, kb]
for (let i = 0; i < 192; i++) {
    t = types[getRndInteger(0, 7)]
    n = "name" + getRndInteger(100, 999)
    d = "detail" + getRndInteger(100, 999)
    p = "price" + getRndInteger(10000, 100000)
    temp = { type: t, name: n, detail: d, price: p }
    reszek.push(temp)
}

for (let i = 0; i < reszek.length; i++) {
    switch (reszek[i].type) {
        case "Motherboard":
            document.getElementById("mb").innerHTML += `<option>${reszek[i].name}</option>`
            break
        case "CPU":
        document.getElementById("cpu").innerHTML += `<option>${reszek[i].name}</option>`
        break
        case "RAM":
            document.getElementById("ram").innerHTML += `<option>${reszek[i].name}</option>`
            break
        case "GPU":
            document.getElementById("graf").innerHTML += `<option>${reszek[i].name}</option>`
            break
        case "HDD":
            document.getElementById("hdd").innerHTML += `<option>${reszek[i].name}</option>`
            break
        case "Monitor*":
            document.getElementById("monitor").innerHTML += `<option>${reszek[i].name}</option>`
            break
        case "Mouse*":
            document.getElementById("m").innerHTML += `<option>${reszek[i].name}</option>`
            break
        case "Keyboard*":
            document.getElementById("kb").innerHTML += `<option>${reszek[i].name}</option>`
            break
    }
}
