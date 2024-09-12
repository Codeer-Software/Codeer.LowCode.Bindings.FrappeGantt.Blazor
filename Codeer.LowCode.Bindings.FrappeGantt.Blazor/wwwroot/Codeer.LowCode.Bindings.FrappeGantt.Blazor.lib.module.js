/**
 *
 * @param {string} src
 * @returns {void}
 */
function installScript(src) {
  const script = document.createElement("script");
  script.setAttribute("src", src);
  document.body.appendChild(script);
}

/**
 *
 * @param {string} src
 * @returns {void}
 */
function installCss(src) {
  const link = document.createElement("link");
  link.setAttribute("rel", "stylesheet");
  link.setAttribute("href", src);
  document.head.appendChild(link);
}

function startup() {
  installCss("_content/FrappeGanttJS.Blazor/style.css");
  installScript("_content/FrappeGanttJS.Blazor/frappe-gantt.umd.js");
  installScript("_content/FrappeGanttJS.Blazor/main.js");
}

export function beforeStart() {
  startup();
}

export function beforeWebStart() {
  startup();
}
