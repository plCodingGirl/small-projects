const button = document.querySelector("button")
const input = document.querySelector("input")
const header = document.querySelector("thead tr")
const numerOfWeeks = 53;

for (let week = 1; week <= numerOfWeeks; week++) {
    const el = document.createElement("th")
    el.innerText = week
    header.appendChild(el)
}

button.addEventListener("click", e => { 
    const body = document.querySelector("tbody")
    while (body.firstChild) {
        body.firstChild.remove()
    }

    if (!input.valueAsDate) {
        return;
    }

    const weeksPassed = weeksBetween(new Date(), input.valueAsDate)

    for (let year = 1; year <= 80; year++) {
        const row = document.createElement("tr")
        body.appendChild(row)
        const el = document.createElement("td")
        el.innerText = year
        row.appendChild(el)
        for (let week = 1; week <= numerOfWeeks; week++) {
            const el = document.createElement("td")
            if(week + ((year - 1) * numerOfWeeks) <= weeksPassed) {
                el.classList.add("passed")
            }
            row.appendChild(el)
        }
    }
})

function weeksBetween(d1, d2) {
    return Math.abs(Math.round((d2 - d1) / (7 * 24 * 60 * 60 * 1000)));
}
