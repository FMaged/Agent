using Microsoft.Extensions.Logging;

namespace Agent
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

/*
JobSearchApp/
├── Core/                  # Clean Architecture's "Core" Layer (Domain + Application)
│   ├── Domain/            # DDD Core
│   │   ├── Entities/      # Job, Company, UserProfile, Application
│   │   ├── ValueObjects/  # SalaryRange, Location, JobType
│   │   ├── Enums/         # JobCategory, ExperienceLevel
│   │   ├── Exceptions/    # JobNotFoundException, InvalidJobApplicationException
│   │   ├── Interfaces/    # IJobRepository, IUserRepository
│   │   └── Services/      # Domain Services (JobMatcher, SalaryCalculator)
│   │
│   └── Application/       # Use Cases/Application Layer
│       ├── UseCases/      # SearchJobsUseCase, ApplyToJobUseCase, SaveJobUseCase
│       ├── DTOs/          # JobDTO, ApplicationDTO, SearchFilters
│       ├── Interfaces/    # IJobSearchApi, INotificationService
│       └── Services/      # Application Services (JobSearchService)
│
├── Infrastructure/        # External Implementations
│   ├── Repositories/      # JobRepository, UserRepository
│   ├── APIs/              # JobSearchApiClient, LinkedInApiClient
│   ├── Database/          # AppDbContext, EntityConfigurations
│   └── Services/          # PushNotificationService, EmailService
│
├── Presentation/          # MVVM Layer (Platform-Specific UI)
│   ├── Features/          # Feature-Based Organization
│   │   ├── JobSearch/
│   │   │   ├── Views/     # SearchPage.xaml, SearchPage.xaml.cs
│   │   │   ├── ViewModels/ # SearchViewModel.cs
│   │   │   └── Models/    # SearchResultUI.cs
│   │   │
│   │   ├── JobDetails/
│   │   ├── Authentication/
│   │   └── Profile/
│   │
│   ├── Shared/            # Reusable Components
│   │   ├── Components/    # JobCard.razor, FilterChips.xaml
│   │   ├── Converters/    # SalaryFormatter, DateToRelativeTimeConverter
│   │   └── Resources/     # Styles, Colors, Icons
│   │
│   └── Services/          # Platform-Specific Services
│       ├── NavigationService.cs
│       └── DialogService.cs
│
├── Tests/                 # Testing Projects
│   ├── UnitTests/         # Core + Infrastructure Tests
│   └── UITests/           # Presentation Layer Tests
│
└── CrossCutting/          # Shared Utilities
    ├── DependencyInjection/ # DI Configuration
    └── Logging/           # Serilog/ILogger Config
*/
