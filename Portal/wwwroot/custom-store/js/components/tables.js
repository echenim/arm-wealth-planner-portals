!function(l){"use strict";function i(t){l(t).each(function(){var d=l(this),t=d.find("th.brk-tables_active"),a=d.find("th").index(t),e=d.find("td:nth-child("+(a+1)+")"),i=d.find("th:nth-child("+(a+1)+")");e.addClass("brk-tables_active"),i.addClass("brk-tables_active"),d.on("mouseover","td, th",function(){var t=l(this).parent().find("td"),a=l(this).parent().find("th"),e=l.inArray(this,t),i=l.inArray(this,a),n=e+1||i+1;if(1<n){var r=d.find("td:nth-child("+n+")"),s=d.find("th:nth-child("+n+")");r.addClass("brk-tables_hover"),s.addClass("brk-tables_hover")}}).on("mouseout","td, th",function(){var t=l(this).parent().find("td"),a=l(this).parent().find("th"),e=l.inArray(this,t),i=l.inArray(this,a),n=e+1||i+1,r=d.find("td:nth-child("+n+")"),s=d.find("th:nth-child("+n+")");r.removeClass("brk-tables_hover"),s.removeClass("brk-tables_hover")})})}Berserk.behaviors.tables_hv_init={attach:function(t,a){l(t).parent().find(".brk-tables-trend:not(.rendered)").addClass("rendered").each(function(){i(l(this))})}},Berserk.behaviors.data_tables_init={attach:function(t,a){var e=l(t).parent().find(".brk-tables-strict:not(.rendered)").addClass("rendered");if(e.length){if(void 0===l.fn.DataTable)return console.log("Waiting for the DataTable library"),void setTimeout(Berserk.behaviors.data_tables_init.attach,a.timeout_delay,t,a);e.each(function(){var t=l(this);i(t),t.find("table").each(function(){l(this).DataTable(),setTimeout(function(){l(".brk-tables").each(function(){var t=l(this),a=t.find(".dataTables_info, .dataTables_paginate"),e=t.find(".dataTables_paginate"),i=e.find(".first"),n=e.find(".previous"),r=e.find(".next"),s=e.find(".last");a.wrapAll('<div class="brk-tables-lines__sort-nav"></div>'),i.prepend('<i class="fa fa-angle-double-left"></i>'),n.prepend('<i class="fa fa-angle-left"></i>'),r.prepend('<i class="fa fa-angle-right"></i>'),s.prepend('<i class="fa fa-angle-double-right"></i>')})},400)})})}}};var t=l("input,textarea");t.on("focus",function(){l(this).data("placeholder",l(this).attr("placeholder")),l(this).attr("placeholder","")}),t.on("blur",function(){l(this).attr("placeholder",l(this).data("placeholder"))})}(jQuery);