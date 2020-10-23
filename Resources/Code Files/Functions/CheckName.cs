private bool CheckName(string name)
    {
        if (name.Length < 2) { return false; }

        string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz- ";

        string[] split;

        try {
            split = name.Split(' ');
            if (split.Length >= 2) {
                //Do Nothing
            } else {
                return false;
            }
        } catch {
            return false;
        }

        for (int i = 0; i < name.Length; i += 1) {
            if (acceptedChars.Contains(name[i])) {
                //Do Nothing
            } else {
                return false;
            }
        }

        return true;
    }
