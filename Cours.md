Autres notes :

Slidev : powerpoint en mieux, surtout pour les dev.

Conventional Commits : pour générer des changeLogs -> changement majeurs(qui changent complètement la structure du programme) mineurs et “patchs” 1.1.1

entretiens des mises à jours : 
lts (long terme) -> 1.6 = 2 ans, sts (standard terme) -> 1.7 = 1 an

fork -> bifurcation du code de base dans un autre projet différent séparé.

# .NET

.NET est un framework de developpement cross-platform et open-source concu par Microsoft.

Voici un apperçu des technologies .NET:

![Alt text](image.png)

La premiere difference entre .NET et .NET Core est que .NET Core est open-source et cross-platform, tandis que .NET Framework est proprietaire et ne fonctionne que sur Windows.

La portabilite de .NET Core est possible car il ne depend pas de Windows, mais de CoreCLR, une version de CLR (Common Language Runtime) qui est cross-platform.

Les librairies NuGet : .NET Core utilise les librairies NuGet, qui sont des librairies open-source, tandis que .NET Framework utilise les librairies proprietaires de Microsoft.
Cependant toutes les librairies .NET Framework ne sont pas encore portees sur .NET Core.

## .NET Core

L'une des premieres technologies introduites par .NET Core et ASP .NET Core, qui est un framework web open-source et cross-platform, qui permet de :

- d'unifier les API UI et Web API
- d'integrer des frameworks client-side comme Angular, React, Vue.js
- de s'integrer facilement dans un environnement cloud
- d'hebeger des applications avec Docker, Apache, Nginx, ...

## Le pattern MVC

.NET utilise le pattern MVC (Model-View-Controller) pour developper des applications web:

- Separation des couches logiques, metier et presentation
- Razor Pages permet de creer des pages Web
- du Model Binding et de la validation de Model

l
Voici l'architecture d'un projet .NET console (cf projet), pour en creer une il suffit de taper la commande suivante :

```bash
dotnet new console
```

On remarque que le contenu du code source est alors constituee d'une seule ligne dans le fichier Program.cs :

```csharp
Console.WriteLine("Hello World!");
```

Si on veut obtenir un programme avec l'ancienne syntaxe, il suffit de taper la commande suivante :

```bash
dotnet new console --use-program-main
```

Pour lancer le programme, il suffit de taper la commande suivante :

```bash
dotnet run
```

Pour creer un projet MVC, il suffit de taper la commande suivante :

```bash
dotnet new mvc
```

Le serveur Web fournir avec ASP .NET Core est Kestrel, qui est un serveur Web cross-platform.

![Alt text](image-1.png)

Kestrel va traiter toutes les requetes et fournira les reponses au travers d'un objet de type `HttpContext`.

## La convergence des frameworks .NET avec la version 5.0

![Alt text](image-2.png)

## Les composants de .NET Core

1. Les librairies CoreFX

Ces librairies integrent toutes les classes de bases de .NET Core et disponibles sous l'espace de nom `System.*`. (namespace).

La grande majotrite des API de Core FX sont aussi disponibles sur .NET Framework classique.
L'equivalent de CoreFX sur .NET Framework est le .NET Framework Class Library (FCL/BCL). CoreFX est en quelque sorte un **fork** de FCL/BCL.

## Le langage C#

C# est un langage de programmation oriente objet, qui est tres proche du Java.

### Version 7.0

Qu'est-ce qu'un tuple ???

```cs
// Tuple en csharp 7.0 anonyme
var letters = ("a", "b");
letters.Item1; // a
letters.Item2; // b

// tuple nommé
(String Alpha, String Beta) letters = ("a", "b");
var alphabet = (Alpha: "a", Beta: "b");
alphabet.Alpha; // a
alphabet.Beta; // b
```

```cs
    private static (int Max, int Min) Range(IEnumerable<int> numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        foreach (var n in numbers[1..])
        {
            min = n < min ? n : min;
            max = n > max ? n : max;
        }
        return (max, min);
    }

```

```cs
    public static int Sum(IEnumerable<object> values)
    {
        var sum = 0;
        foreach (var item in values)
        {
            switch (item)
            {
                case 0;
                break;
                case int val:
                sum += val;
                break;
                case IEnumerable<object> subList when subList.Any():
                sum += Sum(subList);
            }
        }
    }

```

### Version 7.1

```cs
int count = 5;
string label = "Colors used in the map";

var pair = (count, label);
pair.count // 5
```

On peut maintenant utiliser le mot cle `async` dans les noms de methodes main, par exemple :

```cs
public static async Task Main()
{
    await DoSomethingAsync();
}
```

### Version 7.2

Nouveautes :

- le mot-clé `in` pour les paramètres de méthode: la variable est passée par référence, mais ne peut pas être modifiée
- le mot cle `ref readonly` pour les parametres de methode: la variable est passée par référence, mais ne peut pas être modifiée
- le mot cle `readonly struct` : la struct est immutable et ne peut etre transferee qu'avec le mot cle `in`

### Version 8.0

```cs
String? s = null;
Console.WriteLine(s);
```

En C#, il est possbible de fournir une implemenmtation par defaut pour les interfaces, par exemple :

cf projet exemple

En C#, il est possible de declarer assez facielement une sequence de valeurs, par exemple :

```cs
// Range
var maRange = array[4..^2];
// Output

```

## Les fonctionnalites de .NET Core

### Le cli

les commandes utiles :

- dotnet new : initialise un nouveau projet
- dotnet restore : restaure les packages
- dotnet build : compile le projet
- dotnet run : execute le projet
- dotnet test : execute les tests unitaires
- dotnet publish : publie le projet
- dotnet pack : cree un package NuGet

Etapes pour la configuration de SQLite avec EF Core:
- Ajouter le package NuGet Microsoft.EntityFrameworkCore.Sqlite
- Ajouter le package NuGet Microsoft.EntityFrameworkCore.Design
- installer les outils de ligne de commande : dotnet tool install -- global dotnet-ef
- Creer une classe qui herite de DbContext
- Ajouter une propriete de type DbSet<T> pour chaque entite
- Ajouter une methode OnConfiguring pour configurer la connexion a la base de donnees
- Trouver un moyen de specifier le bon chemin pour le fichier de la base de donnees
- utiliser les commandes de migration pour creer la premiere migration : dotnet ef migrations add
InitialCreate
- analyser le code genere par la migration, d'apres vous a quoi cela va servir ?
- utiliser les commandes de migration pour creer la base de donnees : dotnet ef database update
- que s'est il passe ?