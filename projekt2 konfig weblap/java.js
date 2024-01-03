function getRndInteger(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

(mb = {
  type: "Motherboard",
  name: "Preset",
  detail: "Detail1",
  price: "30000",
  image: "turq.png",
}),
  (cpu = {
    type: "CPU",
    name: "Preset",
    detail: "Detail1",
    price: "50000",
    image: "blue.png",
  }),
  (ram = {
    type: "RAM",
    name: "Preset",
    detail: "Detail1",
    price: "20000",
    image: "green.png",
  }),
  (gpu = {
    type: "GPU",
    name: "Preset",
    detail: "Detail1",
    price: "100000",
    image: "yellow.png",
  }),
  (hdd = {
    type: "HDD",
    name: "Preset",
    detail: "Detail1",
    price: "40000",
    image: "violet.png",
  }),
  (monitor = {
    type: "Monitor*",
    name: "Preset",
    detail: "Detail1",
    price: "90000",
    image: "pink.png",
  }),
  (mouse = {
    type: "Mouse*",
    name: "Preset",
    detail: "Detail1",
    price: "25000",
    image: "red.png",
  }),
  (kb = {
    type: "Keyboard*",
    name: "Preset",
    detail: "Detail1",
    price: "45000",
    image: "orange.png",
  });
reszek = [mb, cpu, ram, gpu, hdd, monitor, mouse, kb];

function populate() {
  for (let i = 0; i < reszek.length; i++) {
    switch (reszek[i].type) {
      case "Motherboard":
      case "type1":
        document.getElementById(
          "mb"
        ).innerHTML += `<option value="${reszek[i].price}" color="${reszek[i].image}">${reszek[i].name}</option>`;
        break;
      case "CPU":
      case "type2":
        document.getElementById(
          "cpu"
        ).innerHTML += `<option value="${reszek[i].price}" color="${reszek[i].image}">${reszek[i].name}</option>`;
        break;
      case "RAM":
      case "type3":
        document.getElementById(
          "ram"
        ).innerHTML += `<option value="${reszek[i].price}" color="${reszek[i].image}">${reszek[i].name}</option>`;
        break;
      case "GPU":
      case "type4":
        document.getElementById(
          "graf"
        ).innerHTML += `<option value="${reszek[i].price}" color="${reszek[i].image}">${reszek[i].name}</option>`;
        break;
      case "HDD":
      case "type5":
        document.getElementById(
          "hdd"
        ).innerHTML += `<option value="${reszek[i].price}" color="${reszek[i].image}">${reszek[i].name}</option>`;
        break;
      case "Monitor*":
      case "type6":
        document.getElementById(
          "monitor"
        ).innerHTML += `<option value="${reszek[i].price}" color="${reszek[i].image}">${reszek[i].name}</option>`;
        break;
      case "Mouse*":
      case "type7":
        document.getElementById(
          "m"
        ).innerHTML += `<option value="${reszek[i].price}" color="${reszek[i].image}">${reszek[i].name}</option>`;
        break;
      case "Keyboard*":
      case "type8":
        document.getElementById(
          "kb"
        ).innerHTML += `<option value="${reszek[i].price}" color="${reszek[i].image}">${reszek[i].name}</option>`;
        break;
    }
  }
  reszek = [];
}
populate();

colors = ["turq", "blue", "green", "yellow", "violet", "pink", "red", "orange"];

function generate() {
  document.getElementById("pop").style.visibility = "hidden";
  types = [
    "Motherboard",
    "CPU",
    "RAM",
    "GPU",
    "HDD",
    "Monitor*",
    "Mouse*",
    "Keyboard*",
  ];

  for (let i = 0; i < 200; i++) {
    t = types[getRndInteger(0, 7)];
    n = "Name" + getRndInteger(100, 999);
    d = "Detail" + getRndInteger(100, 999);
    p = getRndInteger(10000, 100000);
    c = colors[getRndInteger(0, 7)] + ".png";
    temp = { type: t, name: n, detail: d, price: p, image: c };
    reszek.push(temp);
  }
  populate();
}

function teljesAr(actual) {
  document.getElementById("teljesArIro").innerHTML = "Teljes ár: ";
  var ar = 0;
  ar += Number(document.getElementById("mb").value);
  ar += Number(document.getElementById("cpu").value);
  ar += Number(document.getElementById("ram").value);
  ar += Number(document.getElementById("graf").value);
  ar += Number(document.getElementById("hdd").value);
  ar += Number(document.getElementById("monitor").value);
  ar += Number(document.getElementById("m").value);
  ar += Number(document.getElementById("kb").value);
  if (ar > 0) {
    document.getElementById("teljesArIro").innerHTML += ar + " Ft";
    if (document.getElementById("mb").value > 0)
      document.getElementById("mbar").innerHTML =
        document.getElementById("mb").value + " Ft";
    if (document.getElementById("cpu").value > 0)
      document.getElementById("cpuar").innerHTML =
        document.getElementById("cpu").value + " Ft";
    if (document.getElementById("ram").value > 0)
      document.getElementById("ramar").innerHTML =
        document.getElementById("ram").value + " Ft";
    if (document.getElementById("graf").value > 0)
      document.getElementById("grafar").innerHTML =
        document.getElementById("graf").value + " Ft";
    if (document.getElementById("hdd").value > 0)
      document.getElementById("hddar").innerHTML =
        document.getElementById("hdd").value + " Ft";
    if (document.getElementById("monitor").value > 0)
      document.getElementById("monitorar").innerHTML =
        document.getElementById("monitor").value + " Ft";
    else document.getElementById("monitorar").innerHTML = "";
    if (document.getElementById("m").value > 0)
      document.getElementById("mar").innerHTML =
        document.getElementById("m").value + " Ft";
    else document.getElementById("kbar").innerHTML = "";
    if (document.getElementById("kb").value > 0)
      document.getElementById("kbar").innerHTML =
        document.getElementById("kb").value + " Ft";
    else document.getElementById("kbar").innerHTML = "";
  }
  try {
    if (actual.value > 0) {
      var select = document.getElementById(actual.id);
      var selectedOption = select.options[select.selectedIndex];
      var color = selectedOption.getAttribute("color");
      document.getElementById(
        "image"
      ).innerHTML = `<img src="${color}" alt="${color}"></img>`;
    }
  } catch (error) {
    console.error();
  }
}

function megrendeles() {
  document.getElementById("mbL").style.color = "white";
  document.getElementById("cpuL").style.color = "white";
  document.getElementById("ramL").style.color = "white";
  document.getElementById("grafL").style.color = "white";
  document.getElementById("hddL").style.color = "white";
  if (
    document.getElementById("mb").value == 0 ||
    document.getElementById("cpu").value == 0 ||
    document.getElementById("ram").value == 0 ||
    document.getElementById("graf").value == 0 ||
    document.getElementById("hdd").value == 0
  ) {
    if (document.getElementById("mb").value == 0) {
      document.getElementById("mbL").style.color = "red";
    }
    if (document.getElementById("cpu").value == 0) {
      document.getElementById("cpuL").style.color = "red";
    }
    if (document.getElementById("ram").value == 0) {
      document.getElementById("ramL").style.color = "red";
    }
    if (document.getElementById("graf").value == 0) {
      document.getElementById("grafL").style.color = "red";
    }
    if (document.getElementById("hdd").value == 0) {
      document.getElementById("hddL").style.color = "red";
    }
    document.getElementById("siker").innerHTML =
      "Válasszon ki egyet a kötelező elemek közül!";
  } else
    document.getElementById(
      "siker"
    ).innerHTML = `<p style="color:green">Megrendelés sikeres!</p>`;
}

ertekelesek = []; //Opcionális

function ertekel() {
  temp = {
    num: parseInt(document.getElementById("rate").value),
    text: document.getElementById("opi").value,
  };
  ertekelesek.push(temp);
  document.getElementById(
    "ertekeles"
  ).innerHTML = `<p>Köszönjük! Értékelés elküldve.</p>
    <input type="button" value="Új értékelés" onclick="ujra()">
    <input type="button" value="Korábbi értékelések megjelenitése" onclick="korjel()"><br><br><br><br>`;
  document.getElementById(
    "korert"
  ).innerHTML += `<hr style="color:white;"><p>${temp.num}/5</p><p>${temp.text}</p>`;
}

function ujra() {
  document.getElementById("ertekeles").innerHTML = `<h1>Értékelés</h1>
    <label for="rate">Értékelés: </label>
    <input type="number" id="rate" name="rate" min="1" max="5" style="width: 8%" value="1">
    <label>/5</label>
    <br>
    <label style=" margin-top: 1%;">Szöveges vélemény:</label>
    <textarea name="opi" id="opi" cols="30" rows="10" style="width: 90%;  margin-top: 1%;"></textarea>
    <input type="button" value="Küldés" onclick="ertekel()">
    <input type="button" value="Korábbi értékelések megjelenitése" onclick="korjel()">`;
}

function korjel() {
  document.getElementById("korert").style.visibility = "visible";
}

function korjeldel() {
  document.getElementById("korert").style.visibility = "hidden";
}

function readFile() {
  document.getElementById("pop").style.visibility = "hidden";
  const fileInput = document.getElementById("fileInput");
  const file = fileInput.files[0];
  const reader = new FileReader();

  reader.onload = function (event) {
    const contents = event.target.result;
    const lines = contents.split("\n");
    lines.forEach((line) => {
      if (line.trim() !== "") {
        const [type, name, detail, price, image] = line.split(";");
        if (type && name && detail && price && image) {
          const temp = {
            type: type.trim(),
            name: name.trim(),
            detail: detail.trim(),
            price: parseFloat(price.trim()),
            image: image.trim()
          };
          reszek.push(temp);
        }
      }
    });
    populate();
  };
  reader.readAsText(file);
}
