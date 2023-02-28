﻿/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce.Services.AppEnvironment;

public interface IAppEnvironmentService
{
    void UpdateDependencies (bool useMockServices);
}
