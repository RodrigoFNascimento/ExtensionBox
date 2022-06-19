using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ExtensionBox
{
    public static class ClaimsPrincipalExtension
    {
        /// <summary>
        /// Gets the value of a claim, if <paramref name="claimName"/>
        /// is a key in <paramref name="claimName"/>.
        /// </summary>
        /// <typeparam name="TClaim">Output type of the claim.</typeparam>
        /// <param name="claimName">Key used to find a value in a collection of claims.</param>
        /// <param name="claims">Collection of claims.</param>
        /// <returns>Claim value.</returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the claim can't be found in the collection.
        /// </exception>
        public static TClaim GetClaim<TClaim>(this ClaimsPrincipal claims, string claimName)
        {
            var claim = claims.FindFirst(x => x.Type == claimName);

            _ = claim ?? throw new KeyNotFoundException($"Key {claimName} not found in the collection.");

            return (TClaim)Convert.ChangeType(claim.Value, typeof(TClaim));
        }

        /// <summary>
        /// Gets the value of a claim, if <paramref name="claimName"/>
        /// is a key in <paramref name="claimName"/>. Otherwise, returns
        /// a default value.
        /// </summary>
        /// <typeparam name="TClaim">Output type of the claim.</typeparam>
        /// <param name="claimName">Key used to find a value in a collection of claims.</param>
        /// <param name="claims">Collection of claims.</param>
        /// <param name="defaultValue">
        /// Default value returned if the claim can't be found
        /// or can't be converted to <typeparamref name="TClaim"/>.
        /// </param>
        /// <returns>Claim value.</returns>
        public static TClaim GetClaim<TClaim>(this ClaimsPrincipal claims, string claimName, TClaim defaultValue)
        {
            if (!claims.HasClaim(x => x.Type == claimName))
                return defaultValue;

            return claims.GetClaim<TClaim>(claimName);
        }
    }
}
