(function ($) {
  Berserk.behaviors.auth_init = {
    attach: function (context, settings) {
      $(".brk-login-page:not(.rendered)").addClass("rendered").each(function(){
        var box = $(this).find(".brk-login-page__box");
        var wrp = $(this).find(".brk-login-page__wrapper");
        var width = $(window).width();
        $(window).resize(function() {
          width = $(window).width();
          setMargin();
        });

        function setMargin(){
          box.css("margin-left", function(){
            return width < "992" ?  "20%" : "50%"
          });
        };

        setMargin();

        $(this).find(".brk-sign-in").click(function() {
          setMargin();
          wrp.css("margin-left", "0");
        });

        $(this).find(".brk-sign-up").click(function() {
          box.css("margin-left", "0");
          wrp.css("margin-left", "100%");
        });

      });
    }
  }
})(jQuery);
