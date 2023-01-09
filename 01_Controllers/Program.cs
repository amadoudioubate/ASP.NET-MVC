// On commence par la Cr�ation du WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);




//--------------------------------------------------
//------- Ajout de services � l'application --------
//--------------------------------------------------

// ici on s'abonne � l'ensemble des services dont aura besoin l'application


// Add services to the container.
builder.Services.AddControllersWithViews();

// On s'abonne au service de mise en cache
builder.Services.AddControllersWithViews();






//--------------------------------------------------
//------------ Build l'application -----------------
//--------------------------------------------------
// En suite on va construire (builder) l'application

var app = builder.Build();






//----------------------------------------------------------------------------------
//------- Configuration du pipeline pour construire la r�ponse � la requ�te --------
//----------------------------------------------------------------------------------

// Le pipeline sp�cifie la mani�re dont l'application doit traiter/r�pondre � une requ�te
// Quand l'application re�oit une requ�te du client, cette derni�re va aller/retour � travers le pipeline
// Ce pipeline est constitu� d'une ensemble de middlewares

// Chacun de ces middlewares permet d'adresser un point technique li� � la requ�te

// - La gestion des erreurs
// - La gestion des cookies
// - k'authentification
// - Le routage
// - La mise en cache...


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Si pas en environnement de d�veloppement, on redirige vers l'action 'Error'du controller 'Home' => 'HomeController' en cas d'exception
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // Pour inciter l'utilisateur � utiliser https
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


/*app.MapControllerRoute(
    name: "default",
    pattern: "{action=Privacy}/{controller=Home}/{id?}");*/

// Route (on peut choisir la mani�re de construire mon url par exemple
// pattern: "{action=Index}/{controller=Home}/{id?}");) juste pour explication principe de routage
app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Home}/{action=Index}");


/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=new}/{action=ActionReturnView}/{id?}");*/




// Middleware de mise en cache
app.UseResponseCaching();

app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
    {
        Public = true,
        MaxAge = TimeSpan.FromSeconds(10)
    };

    await next();
});



//-------------------------------------------------------------
//------- Run Application=> ex�cution de l'application --------
//-------------------------------------------------------------
app.Run();
