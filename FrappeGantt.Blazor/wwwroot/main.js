(function () {
  class FrappeGanttInterop {
    constructor(dotnetRef, hostElementId, tasks, options) {
      console.log('FrappeGanttInterop', hostElementId, tasks, options);
      const ganttElement = document.querySelector(hostElementId);
      ganttElement.addEventListener("pointerdown", () => this.#pointerDown());
      const that = this;
      this.processing = false;
      this.gantt = new Gantt(hostElementId, tasks, {
        ...options,
        on_click: function (task) {
          if(!that.processing) return;
          that.processing = false;
          dotnetRef?.invokeMethodAsync('OnClickCallback', task);
        },
        on_date_change: function (task, start, end) {
          if(!that.processing) return;
          that.processing = false;
          dotnetRef?.invokeMethodAsync('OnDateChangeCallback', task, start, end);
        },
        on_progress_change: function (task, progress) {
          if(!that.processing) return;
          that.processing = false;
          dotnetRef?.invokeMethodAsync('OnProgressChangeCallback', task, progress);
        },
        on_view_change: function (mode) {
          dotnetRef?.invokeMethodAsync('OnViewChangeCallback', mode);
        },
      });
    }
    
    #pointerDown(){
      this.processing = true;
    }

    setDataSource(tasks) {
      this.gantt.refresh(tasks);
    }

    setViewMode(mode) {
      this.gantt.change_view_mode(mode);
    }
    
    getStartDate() {
      return this.gantt.gantt_start;
    }
    
    getEndDate() {
      return this.gantt.gantt_end;
    }
  }

  function create(dotnetRef, id, tasks, options = {}) {
    return new FrappeGanttInterop(dotnetRef, id, tasks, options);
  }

  window.FrappeGanttModule = {create};
})();