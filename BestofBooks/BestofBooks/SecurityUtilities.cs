using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace BestofBooks
{
    public static class SecurityUtilities
    {
        // Number of iterations — higher = slower to brute-force.
        // 100,000 is the current OWASP minimum recommendation for PBKDF2-SHA256.
        private const int Iterations = 100_000;

        // Salt length in bytes — 16 bytes (128 bits) is standard.
        private const int SaltSize = 16;

        // Hash output length in bytes — 32 bytes (256 bits).
        private const int HashSize = 32;

        /// <summary>
        /// Hashes a plain-text password using PBKDF2 with a random salt.
        /// Returns a single storable string in the format: base64(salt):base64(hash)
        /// Each call produces a different output even for the same password.
        /// </summary>
        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            // Generate a cryptographically random salt
            byte[] salt = new byte[SaltSize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            byte[] hash = Pbkdf2(password, salt);

            // Store salt and hash together so we can verify later
            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        /// <summary>
        /// Verifies a plain-text password against a stored hash string.
        /// The stored string must be in the format produced by HashPassword.
        /// </summary>
        public static bool userLoggedIn(string storedHash, string password)
        {
            if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(password))
                return false;

            var parts = storedHash.Split(':');

            // If the stored value isn't in our new format, it's an old SHA256 hash.
            // Fall back to the legacy check so existing accounts still work
            // until their password is reset or they log in and get upgraded.
            if (parts.Length != 2)
                return LegacyCheck(storedHash, password);

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] expectedHash = Convert.FromBase64String(parts[1]);
            byte[] actualHash = Pbkdf2(password, salt);

            // Constant-time comparison — prevents timing attacks
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }

        // ── Private helpers ───────────────────────────────────────────────────

        private static byte[] Pbkdf2(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: HashSize);
        }

        /// <summary>
        /// Legacy SHA256 check for any passwords stored before this update.
        /// Once all passwords are re-hashed this can be removed.
        /// </summary>
        private static bool LegacyCheck(string storedHash, string password)
        {
            var sb = new System.Text.StringBuilder();
            using var sha = System.Security.Cryptography.SHA256.Create();
            foreach (byte b in sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)))
                sb.Append(b.ToString("X2"));
            return storedHash == sb.ToString();
        }
    }
}