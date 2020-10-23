private static bool CheckEmail(string email)
        {
            const string acceptableDomainChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.";
            const string acceptableStartChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string specialChars = "!#$%&'*+-/=?^_`.{|}~";

            string[] splitForAt; // Splits the text at the @ symbo

            try
            {
                splitForAt = email.Split('@');

                if (splitForAt.Length != 2) { return false; }
            }
            catch { return false; } // Does not contain '@' symbol

            string domain = splitForAt[1];

            if (domain.Contains('.')) { } else { return false; }

            for (int i = 0; i < domain.Length; i += 1)
            {
                if (acceptableDomainChars.Contains(domain[i])) { } else { return false; }
            }

            if (acceptableStartChars.Contains(email[0])) { } else { return false; }

            for (int i = 0; i < email.Length - 1; i += 1)
            {
                if (specialChars.Contains(email[i]))
                {
                    if (email[i + 1] == email[i]) { return false; }
                }
            }

            return true;
        }
